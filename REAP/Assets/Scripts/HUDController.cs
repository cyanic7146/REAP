using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;

public class HUDController : MonoBehaviour
{
    public UIDocument uiDocument;

    Label ageLabel;
    Label moneyLabel;
    Label debtLabel;
    Label creditScoreLabel;
    Button statsButton;
    VisualElement StatsContainer;

    IEnumerator Start()
    {
        yield return null;

        ageLabel = uiDocument.rootVisualElement.Q<Label>("ageLabel");
        moneyLabel = uiDocument.rootVisualElement.Q<Label>("moneyLabel");
        debtLabel = uiDocument.rootVisualElement.Q<Label>("debtLabel");
        creditScoreLabel = uiDocument.rootVisualElement.Q<Label>("creditScoreLabel");
        statsButton = uiDocument.rootVisualElement.Q<Button>("statsButton");
        statsButton.RegisterCallback<ClickEvent>(StatsButtonClicked);
        StatsContainer = uiDocument.rootVisualElement.Q<VisualElement>("StatsContainer");

        UpdateStats();
    }

    public void UpdateStats()
    {

        ageLabel.text = $"Age: {PlayerStats.Instance.age}";
        moneyLabel.text = $"Money: ${PlayerStats.Instance.money:F2}";
        debtLabel.text = $"Debt: ${PlayerStats.Instance.debt:F2}";
        creditScoreLabel.text = $"Credit Score: {PlayerStats.Instance.creditScore}";
    }
    void StatsButtonClicked(ClickEvent evt)
    {
        if (StatsContainer.ClassListContains("stats-hidden"))
        {
            StatsContainer.RemoveFromClassList("stats-hidden");
            StatsContainer.AddToClassList("stats-visible");
            statsButton.text = "HideStats";
        }
        else
        {
            StatsContainer.AddToClassList("stats-hidden");
            StatsContainer.RemoveFromClassList("stats-visible");
            statsButton.text = "ShowStats";
        }
    }
    void OnDestroy()
{
    
        statsButton.UnregisterCallback<ClickEvent>(StatsButtonClicked);
}

}
