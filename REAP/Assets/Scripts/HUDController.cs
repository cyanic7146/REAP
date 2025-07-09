using UnityEngine;
using UnityEngine.UIElements;

public class HUDController : MonoBehaviour
{
    public UIDocument uiDocument;

    Label ageLabel;
    Label moneyLabel;
    Label debtLabel;
    Label creditScoreLabel;

    void Start()
    {

        ageLabel = uiDocument.rootVisualElement.Q<Label>("ageLabel");
        moneyLabel = uiDocument.rootVisualElement.Q<Label>("moneyLabel");
        debtLabel = uiDocument.rootVisualElement.Q<Label>("debtLabel");
        creditScoreLabel = uiDocument.rootVisualElement.Q<Label>("creditScoreLabel");

        UpdateStats();
    }

    public void UpdateStats()
    {

        ageLabel.text = $"Age: {PlayerStats.Instance.age}";
        moneyLabel.text = $"Money: ${PlayerStats.Instance.money:F2}";
        debtLabel.text = $"Debt: ${PlayerStats.Instance.debt:F2}";
        creditScoreLabel.text = $"Credit Score: {PlayerStats.Instance.creditScore}";
    }
}
