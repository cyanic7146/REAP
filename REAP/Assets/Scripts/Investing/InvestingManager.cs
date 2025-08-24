using System.Collections.Generic;
using UnityEngine;

public class InvestingManager : MonoBehaviour
{
    public List<Company> Companies { get; private set; } = new List<Company>();
    private System.Random rng = new System.Random();

    void Start()
    {
        Companies.Add(new Company("1", 100f, 0.08f, 0.25f));
        Companies.Add(new Company("2", 70f, 0.05f, 0.15f));
        Companies.Add(new Company("3", 150f, 0.10f, 0.30f));

        for (int i = 0; i < 10; i++)
        {
            Debug.Log($"Year {i + 1}:");
            SimulateYear();
        }
        foreach (var company in Companies)
        {
            Debug.Log(company.Name + " Price History: " + string.Join(", ", company.PriceHistory));
        }

    }

    public void SimulateYear()
    {
        foreach (var company in Companies)
        {
            company.SimulateYear(rng);
            //Debug.Log($"{company.Name} is now ${company.CurrentPrice:F2}");
        }
    }
}
