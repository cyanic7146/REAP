using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance; // PlayerStats.Instance.anythinginthisclass += something

    public int age = 18;
    public float money = 6000f;
    public float debt = 100000f;
    public float creditScore = 700f;
    public string jobTitle = "None";
    public string education = "High School";
    public bool isInCollege = false;
    public float income = 100f;
    public float expenses = 100f;
    public float inflation = 1.025f;
    public float rent = 1000f;
    public float food = 100f;
    public float transportation = 8f;
    public float entertainment = 4f;
    public float utilities = 10f;
    public float collegetuition = 14f;
    public float inflationThisYear = 1.025f;
    public int year = 0;

    void Awake()
    {
        if (Instance != null && Instance != this) // prevents conflict 
        {
            Debug.LogWarning("multiple playerstats instances CHECK YOUR CODE!!!");
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); // won't be destoryed onload
    }
}
