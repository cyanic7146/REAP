
using UnityEngine;
using UnityEngine.UIElements;

public class LivingCostUI : MonoBehaviour
{
    private VisualElement root;
    private Label summaryLabel;
    

    private VisualElement financePage;
    private VisualElement companyPage;


    private Button financeButton;
    private Button companyButton;

    void OnEnable()
    {

        root = GetComponent<UIDocument>().rootVisualElement;


        summaryLabel = root.Q<Label>("SummaryLabel");
        
        financePage = root.Q<VisualElement>("FinancePage");
        companyPage = root.Q<VisualElement>("CompanyPage");

        financeButton = root.Q<Button>("FinanceButton");
        companyButton = root.Q<Button>("CompanyButton");

        // Register button click events
        financeButton.RegisterCallback<ClickEvent>(evt => ShowFinancePage());
        companyButton.RegisterCallback<ClickEvent>(evt => ShowCompanyPage());

        // Set the initial state
        ShowFinancePage();
    }

    public void UpdateSummaryText(string text)
    {
        if (summaryLabel != null)
        {
            summaryLabel.text = text;
        }
    }

    private void ShowFinancePage()
    {
        financePage.style.display = DisplayStyle.Flex;
        companyPage.style.display = DisplayStyle.None;
        
        financeButton.AddToClassList("active-button");
        companyButton.RemoveFromClassList("active-button");
    }

    private void ShowCompanyPage()
    {
        financePage.style.display = DisplayStyle.None;
        companyPage.style.display = DisplayStyle.Flex;
        
        companyButton.AddToClassList("active-button");
        financeButton.RemoveFromClassList("active-button");
    }
}