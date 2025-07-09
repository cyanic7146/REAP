using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance; // PlayerStats.Instance.anythinginthisclass += something

    public int age = 18;
    public float money = 0f;
    public float debt = 0f;
    public float creditScore = 700f;
    public string jobTitle = "None";
    public string education = "High School";
    public bool isInCollege = false;
    public float income = 0f;
    public float expenses = 0f;
    public float inflation = 1.025f;

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
