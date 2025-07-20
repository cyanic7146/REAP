using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public void AdvanceYear()
    {

        PlayerStats.Instance.age += 1;

        PlayerStats.Instance.debt += PlayerStats.Instance.debt * 1.06f;

        PlayerStats.Instance.money += PlayerStats.Instance.income;

        PlayerStats.Instance.money -= PlayerStats.Instance.expenses;

        Debug.Log("A year has passed, you are now " + PlayerStats.Instance.age);
    }

    void totalExpenses()
    {
        PlayerStats.Instance.expenses = PlayerStats.Instance.rent + PlayerStats.Instance.food + PlayerStats.Instance.transportation + PlayerStats.Instance.entertainment + PlayerStats.Instance.utilities;

        Debug.Log("Total expenses for the year: " + PlayerStats.Instance.expenses);
    }
}
