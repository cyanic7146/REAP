using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public void AdvanceYear()
    {
        
        PlayerStats.Instance.age += 1;
        
        PlayerStats.Instance.debt += PlayerStats.Instance.debt * 1.06f;

        PlayerStats.Instance.money += PlayerStats.Instance.income;

        PlayerStats.Instance.money -= PlayerStats.Instance.expenses;
                
        Debug.Log($"Year advanced to {PlayerStats.Instance.age}");
    }
}
