using UnityEngine;

public class LivingCostEvent
{
    public string category;
    public float amount;
    public string description;

    public LivingCostEvent(string category, float amount, string description)
    {
        this.category = category;
        this.amount = amount;
        this.description = description;
    }
}
