using System.Collections.Generic;
using UnityEngine;

public class LivingCostManager : MonoBehaviour
{

    void Start()
    {
        List<LivingCostEvent> yearlyEvents = GenerateLivingCostEvents();
        string summary = GenerateSummaryParagraph(yearlyEvents, PlayerStats.Instance.age);
        Debug.Log(summary);
    }
    


    public List<LivingCostEvent> GenerateLivingCostEvents()
    {

        List<LivingCostEvent> events = new List<LivingCostEvent>();

        events.Add(new LivingCostEvent("Rent", 12000f, "You paid rent for your apartment downtown."));

        if (Random.value < 0.2f)
        {
            events.Add(new LivingCostEvent("Healthcare", 4000f, "A sudden hospital visit left you with a hefty medical bill."));
        }

        if (Random.value < 0.4f)
        {
            events.Add(new LivingCostEvent("Travel", 2500f, "You traveled to Japan for a much-needed vacation."));
        }

        if (Random.value < 0.2f)
        {
            events.Add(new LivingCostEvent("Tax Refund", -1500f, "You received a tax refund from overpaying last year."));
        }

        if (Random.value < 0.5f)
        {
            events.Add(new LivingCostEvent("Entertainment", 800f, "You went to concerts, movies, and subscribed to 5 streaming services."));
        }

        if (Random.value < 0.3f)
        {
            events.Add(new LivingCostEvent("Side Hustle", -2000f, "Your friend brought in extra cash."));
        }

        return events;
    }

    public string GenerateSummaryParagraph(List<LivingCostEvent> events, int age)
    {
        string intro = $"<b>Age {age} Summary:</b>\n\n";
        string body = "";
        float total = 0;

        foreach (var e in events)
        {
            float amount = e.amount;
            string sign;
            if (amount < 0)
            {
                sign = "-";
            }
            else
            {
                sign = "+";
            }
            
            string formatted = $"{e.description} ({sign}${Mathf.Abs(e.amount):N0})";
            body += formatted + "\n";
            total += e.amount;
        }

        string outro = "\n";
        string resultText;
        if (total >= 0)
        {
            resultText = "You spent";
        }
        else
        {
            resultText = "You gained";
        }

        float absoluteTotal = Mathf.Abs(total);

        outro += "Net result: " + resultText + " $" + absoluteTotal.ToString("N0") + " this year.";

        return intro + body + outro;
    }
}
