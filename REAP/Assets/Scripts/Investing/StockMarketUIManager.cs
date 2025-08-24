using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StockMarketUIManager : MonoBehaviour
{
    public UIDocument uiDocument;
    public InvestingManager investingManager;
    private VisualElement root;
    private Label companyNameLabel;
    private Label currentPriceLabel;
    private ScrollView stockList;

    private void Awake()
    {
        root = uiDocument.rootVisualElement;

        stockList = root.Q<ScrollView>("stockList");
        companyNameLabel = root.Q<Label>("companyName");
        currentPriceLabel = root.Q<Label>("currentPrice");
    }

    private void Start()
    {
        if (investingManager != null)
        {
            PopulateStockList(investingManager.Companies);
        }
    }

    void PopulateStockList(List<Company> companies)
    {
        stockList.Clear();

        foreach (var company in companies)
        {
            var button = new Button(() => ShowCompanyDetails(company))
            {
                text = $"{company.Name} - ${company.CurrentPrice:F2}"
            };
            stockList.Add(button);
        }
    }

    void ShowCompanyDetails(Company company)
    {
        companyNameLabel.text = company.Name;
        currentPriceLabel.text = $"${company.CurrentPrice:F2}";
    }
}
