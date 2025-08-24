using System.Collections.Generic;
using UnityEngine;

public class Company
{
    public string Name { get; private set; }
    public float CurrentPrice { get; private set; }
    public float Drift { get; private set; }
    public float Volatility { get; private set; }
    public List<float> PriceHistory { get; private set; }

    public Company(string name, float startPrice, float drift, float volatility)
    {
        Name = name;
        CurrentPrice = startPrice;
        Drift = drift;
        Volatility = volatility;
        PriceHistory = new List<float> { startPrice };
    }

    public void SimulateYear(System.Random rng)
    {
        float randStdNormal = Mathf.Sqrt(-2f * Mathf.Log((float)rng.NextDouble())) *
                              Mathf.Cos(2f * Mathf.PI * (float)rng.NextDouble());

        float yearlyReturn = Drift + Volatility * randStdNormal;

        CurrentPrice *= 1f + yearlyReturn;
        PriceHistory.Add(CurrentPrice);
    }
}
