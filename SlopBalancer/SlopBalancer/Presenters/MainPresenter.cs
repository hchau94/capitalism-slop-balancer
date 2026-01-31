namespace SlopBalancer.Presenters;

using Abstractions;
using Services;

public class MainPresenter
{
    private readonly IView _view;
    private readonly IBalanceCalculator _balancer;
    
    public MainPresenter(IView view)
    {
        _view = view;
        _balancer = new BalanceCalculator();

        _view.BalanceClicked += OnBalanceClick;
    }
    
    private void OnBalanceClick(object? sender, EventArgs e)
    {
        var tickers = ProcessTickersInput(_view.Tickers);
        var shares = ProcessSharesInput(_view.CurrentShares);
        var targetPercentages = ProcessTargetsInput(_view.Targets);
        
        _balancer.UpdateStartingData(tickers, shares, targetPercentages);
    }
    
    /// <summary>
    /// Assumes basic CSV like "ticker1, ticker2, etc."
    /// </summary>
    private List<string>? ProcessTickersInput(string tickers)
    {
        var list = new List<string>();

        foreach (var ticker in tickers.Split(','))
        {
            string trimmedString = ticker.Trim();
            if (!string.IsNullOrWhiteSpace(trimmedString))
            {
                list.Add(trimmedString);
            }
        }

        return list;
    }
    
    /// <summary>
    /// Assumes basic CSV like "123.4, 45.67, etc."
    /// </summary>
    private List<decimal>? ProcessSharesInput(string shares)
    {
        var list = new List<decimal>();

        foreach (var numShares in shares.Split(','))
        {
            string trimmedString = numShares.Trim();
            if (!string.IsNullOrWhiteSpace(trimmedString))
            {
                var parsed = decimal.TryParse(trimmedString, out decimal temp) ? temp : 0m;
                list.Add(parsed);
            }
        }

        return list;
    }
    
    /// <summary>
    /// Assumes basic CSV like "10%, 20%, etc."
    /// </summary>
    private List<int>? ProcessTargetsInput(string targets)
    {
        var list = new List<int>();

        foreach (var target in targets.Split(','))
        {
            string trimmedString = target.Trim();
            if (!string.IsNullOrWhiteSpace(trimmedString))
            {
                var parsed = int.TryParse(trimmedString, out int temp) ? temp : 0;
                list.Add(parsed);
            }
        }

        return list;
    }
}