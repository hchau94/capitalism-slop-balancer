namespace SlopBalancer.Services;

using System;
using System.IO;
using System.Text.Json;

using Abstractions;

public class BalanceCalculator : IBalanceCalculator
{
    private readonly List<Investment> _investments;
    private readonly string _apiKey;

    public BalanceCalculator()
    {
        _investments = new List<Investment>();
        
        string json = File.ReadAllText("localConfig.json");
        using JsonDocument doc = JsonDocument.Parse(json);
        JsonElement root = doc.RootElement;
        _apiKey = root.GetProperty("AlphaVantage").GetProperty("ApiKey").GetString(); 
    }

    public async void UpdateStartingData(List<string> tickers, List<decimal> shares, List<int> targetPercentages)
    {
        if (tickers.Count != shares.Count || shares.Count != targetPercentages.Count) return;
        
        for (int i = 0; i < tickers.Count; i++)
        {
            decimal price;
            try
            {
                price = await GetPrice(tickers[i]);
            }
            catch (Exception e)
            {
                price = 0m;
            }
            
            _investments.Add(new Investment(tickers[i], shares[i], price, targetPercentages[i]));
        }
    }

    private async Task<decimal> GetPrice(string ticker)
    {
        using HttpClient client = new HttpClient();
        string url = $"https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={ticker}&apikey={_apiKey}";

        string json = await client.GetStringAsync(url);
        
        using JsonDocument doc = JsonDocument.Parse(json);
        JsonElement root = doc.RootElement;
        
        if (root.TryGetProperty("Global Quote", out JsonElement globalQuote) &&
            globalQuote.TryGetProperty("05. price", out JsonElement priceElement))
        {
            string priceString = priceElement.GetString() ?? "0";
            if (decimal.TryParse(priceString, out decimal price))
            {
                return price;
            }
        }
        
        return 0m;
    }

    public List<Investment> GetRebalancedInvestments(bool addNewCash, bool useBands)
    {
        if (_investments.Count == 0) return new List<Investment>();

        var totalValue = _investments.Sum(x => x.Shares * x.Price);
        
        return null;
    }
}