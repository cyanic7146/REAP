using System;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public void AdvanceYear()
    {

        PlayerStats.Instance.age += 1;
        PlayerStats.Instance.year += 1;

        PlayerStats.Instance.debt += PlayerStats.Instance.debt * 1.06f;

        PlayerStats.Instance.money += PlayerStats.Instance.income;

        PlayerStats.Instance.money -= PlayerStats.Instance.expenses;

        Debug.Log("A year has passed, you are now " + PlayerStats.Instance.age);
    }

    public float inflationThisYear()
    {
        return (float)Math.Pow(PlayerStats.Instance.inflation, PlayerStats.Instance.year - 1);
    }
}
