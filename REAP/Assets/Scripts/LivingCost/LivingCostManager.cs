using System.Collections.Generic;
using UnityEngine;

public class LivingCostManager : MonoBehaviour
{
    public LivingCostUI uiManager;

    void Start()
    {
        GenerateAndDisplayYearlySummary();
    }

    public void GenerateAndDisplayYearlySummary()
    {
        List<LivingCostEvent> yearlyEvents = GenerateLivingCostEvents();
        string summary = GenerateSummaryParagraph(yearlyEvents, PlayerStats.Instance.age);

        if (uiManager != null)
        {
            uiManager.UpdateSummaryText(summary);
        }
        else
        {
            Debug.LogWarning("UI Manager is not assigned in the LivingCostManager!");
            Debug.Log(summary);
        }
        
        foreach (var e in yearlyEvents)
        {
            PlayerStats.Instance.money -= e.amount; 
        }

        PlayerStats.Instance.age++;
    }

    public List<LivingCostEvent> GenerateLivingCostEvents()
    {
        List<LivingCostEvent> events = new List<LivingCostEvent>();
        float inflation = PlayerStats.Instance.inflationThisYear;

        events.Add(new LivingCostEvent("Housing", 14000f * inflation, "You paid your annual rent and utilities."));
        events.Add(new LivingCostEvent("Food", 5500f * inflation, "You paid for groceries and basic dining."));
        events.Add(new LivingCostEvent("Transportation", 2000f * inflation, "You paid for your regular commute and transportation needs."));

        if (Random.value < 0.75f)
        {
            float homeRoll = Random.value;
            if (homeRoll < 0.6f)
            {
                float cost = Random.Range(100f, 400f) * inflation;
                events.Add(new LivingCostEvent("Housing", cost, "A leaky pipe under the sink required a plumber."));
            }
            else if (homeRoll < 0.9f)
            {
                float cost = Random.Range(800f, 2000f) * inflation;
                string[] appliances = { "refrigerator", "washing machine", "oven", "water heater" };
                string appliance = appliances[Random.Range(0, appliances.Length)];
                events.Add(new LivingCostEvent("Housing", cost, $"Your {appliance} suddenly broke down and needed a full replacement."));

                if (Random.value < 0.5f)
                {
                    float discount = cost * Random.Range(0.15f, 0.3f);
                    events.Add(new LivingCostEvent("Windfall", -discount, "Thankfully, you found a great sale and got a discount on the new appliance."));
                }
            }
            else
            {
                float cost = Random.Range(500f, 2500f) * inflation;
                events.Add(new LivingCostEvent("Entertainment", cost, "You decided it was time for a change and spent a good amount redecorating your living room."));
            }
        }

        if (Random.value < 0.65f)
        {
            float socialRoll = Random.value;
            if (socialRoll < 0.7f)
            {
                float cost = Random.Range(200f, 600f) * inflation;
                events.Add(new LivingCostEvent("Social", cost, "A close friend had a wedding, and you bought a thoughtful and expensive gift."));

                if (Random.value < 0.25f)
                {
                    float travelCost = Random.Range(1500f, 3000f) * inflation;
                    events.Add(new LivingCostEvent("Travel", travelCost, "The wedding was out of the country, requiring flights and a hotel stay."));
                    
                    if (Random.value < 0.20f)
                    {
                        float mishapCost = Random.Range(150f, 500f) * inflation;
                        events.Add(new LivingCostEvent("Setback", mishapCost, "To make things worse, the airline lost your luggage, and you had to buy new clothes for the event."));
                    }
                }
            }
            else
            {
                float cost = Random.Range(2000f, 5000f) * inflation;
                string[] destinations = { "the sunny beaches of Spain", "the historic cities of Italy", "the vibrant culture of Japan", "a relaxing resort in Mexico" };
                string destination = destinations[Random.Range(0, destinations.Length)];
                events.Add(new LivingCostEvent("Travel", cost, $"You booked a spontaneous, much-needed vacation to {destination}."));
            }
        }

        if (Random.value < 0.5f)
        {
            float financialRoll = Random.value;
            if (financialRoll < 0.4f)
            {
                float cost = Random.Range(300f, 1200f) * inflation;
                events.Add(new LivingCostEvent("Setback", cost, "An old, forgotten medical bill from a clinic visit finally arrived in the mail."));
            }
            else if (financialRoll < 0.7f)
            {
                float investment = Random.Range(1000f, 4000f) * inflation;
                events.Add(new LivingCostEvent("Investment", investment, "You saw a promising investment opportunity in the stock market and decided to invest."));

                float outcomeRoll = Random.value;
                if (outcomeRoll < 0.5f)
                {
                    float gain = investment * Random.Range(0.05f, 0.15f);
                    events.Add(new LivingCostEvent("Windfall", -gain, "By the end of the year, your new investment showed a modest but promising gain."));
                }
                else if (outcomeRoll < 0.85f)
                {
                    float loss = investment * Random.Range(0.05f, 0.15f);
                    events.Add(new LivingCostEvent("Story", 0, "Unfortunately, the market dipped, and your investment ended the year with a minor loss."));
                }
                else
                {
                    float gain = investment * Random.Range(0.25f, 0.6f);
                    events.Add(new LivingCostEvent("Windfall", -gain, "Your bet paid off! The investment performed exceptionally well, yielding a significant return."));
                }
            }
            else
            {
                float income = Random.Range(500f, 2500f) * inflation;
                events.Add(new LivingCostEvent("Income", -income, "You picked up a freelance project on the side, bringing in some extra cash."));
            }
        }
        
        if (Random.value < 0.3f)
        {
            float healthRoll = Random.value;
            if (healthRoll < 0.8f)
            {
                float cost = Random.Range(200f, 700f) * inflation;
                events.Add(new LivingCostEvent("Healthcare", cost, "A nasty flu required a doctor's visit and expensive prescription medication."));
            }
            else
            {
                 float cost = Random.Range(1500f, 6000f) * inflation;
                 events.Add(new LivingCostEvent("Healthcare", cost, "You twisted your ankle badly, leading to an emergency room visit and follow-up physical therapy."));
            }
        }

        return events;
    }

    public string GenerateSummaryParagraph(List<LivingCostEvent> events, int age)
    {
        string intro = $"<b>Year End Summary: Age {age}</b>\n\n";
        string body = "";
        float total = 0;

        foreach (var e in events)
        {
            if (e.category == "Story") {
                body += $"{e.description}\n";
                continue;
            }

            string sign = e.amount < 0 ? "-" : "+";
            body += $"{e.description} <b>({sign}${Mathf.Abs(e.amount):N0})</b>\n";
            total += e.amount;
        }

        string resultText = total >= 0 ? "You had a net expense of" : "You had a net gain of";
        string outro = $"\nOverall: {resultText} <b>${Mathf.Abs(total):N0}</b> this year.";

        return intro + body + outro;
    }
}
