using SlopBalancer.Abstractions;

namespace SlopBalancer.Views;

public partial class MainView : Form
{
    public MainView()
    {
        InitializeComponent();

        radioAddCash.Click += (_, _) => { txtCash.Enabled = true; };
        radioOnlyCurrent.Click += (_, _) => { txtCash.Enabled = false; };
        
        radioAddCash.Click += MaybeEnableBalanceButton;
        radioOnlyCurrent.Click += MaybeEnableBalanceButton;
        txtTickers.TextChanged += MaybeEnableBalanceButton;
        txtCurrentShares.TextChanged += MaybeEnableBalanceButton;
        txtPrices.TextChanged += MaybeEnableBalanceButton;
        txtCurrentShares.TextChanged += MaybeEnableBalanceButton;
        cmdRefresh.Click += MaybeEnableBalanceButton;

        cmdBalance.Click += Rebalance;
    }

    private void MaybeEnableBalanceButton(object sender, EventArgs e)
    {
        if (ConditionsAreMet()) cmdBalance.Enabled = true;
    }

    private bool ConditionsAreMet()
    {
        var textBoxesArePopulated = (!string.IsNullOrWhiteSpace(txtTickers.Text) && !string.IsNullOrWhiteSpace(txtCurrentShares.Text)  && !string.IsNullOrWhiteSpace(txtPrices.Text)  && !string.IsNullOrWhiteSpace(txtTargets.Text));

        var targetInvestmentsCount = txtTickers.Text.Split("\r\n").Length;
        var allInputCountsMatch = txtCurrentShares.Text.Split("\r\n").Length == targetInvestmentsCount && txtPrices.Text.Split("\r\n").Length == targetInvestmentsCount && txtTargets.Text.Split("\r\n").Length == targetInvestmentsCount;

        var modeIsSelected = radioAddCash.Checked || radioOnlyCurrent.Checked;
        
        return textBoxesArePopulated && allInputCountsMatch && modeIsSelected;
    }

    private void Rebalance(object sender, EventArgs e)
    {
        var tickers = ProcessTickers(txtTickers.Text);
        var currentShares = ProcessCurrentShares(txtCurrentShares.Text);
        var prices = ProcessPrices(txtPrices.Text);
        var targets = ProcessTargets(txtTargets.Text);

        var investments = new List<Investment>();
        for (var i = 0; i < tickers.Count; i++)
        {
            investments.Add(new Investment(tickers[i], currentShares[i], prices[i], targets[i]));
        }

        if (radioAddCash.Checked)
        {
            if (string.IsNullOrWhiteSpace(txtCash.Text)) RebalanceWithOnlyCurrentShares(chkOnlyToBands.Checked, investments);
            RebalanceWithNewCash(chkOnlyToBands.Checked, investments);

        }
        else if (radioOnlyCurrent.Checked)
        {
            RebalanceWithOnlyCurrentShares(chkOnlyToBands.Checked, investments);
        }
    }

    private List<string> ProcessTickers(string tickers)
    {
        return tickers.Split("\r\n").ToList();
    }
    
    private List<decimal> ProcessCurrentShares(string currentShares)
    {
        return currentShares.Split("\r\n").Select(x => x.Trim()).Where(x => decimal.TryParse(x, out _)).Select(decimal.Parse).ToList();
    }
    
    private List<decimal> ProcessPrices(string prices)
    {
        return prices.Replace("$", "").Split("\r\n").Select(x => x.Trim()).Where(x => decimal.TryParse(x, out _)).Select(decimal.Parse).ToList();
    }
    
    private List<int> ProcessTargets(string targets)
    {
        return targets.Replace("%", "").Split("\r\n").Select(x => x.Trim()).Where(x => int.TryParse(x, out _)).Select(int.Parse).ToList();
    }

    private void RebalanceWithNewCash(bool onlyToBands, List<Investment> investments)
    {
        var cashToAdd = decimal.TryParse(txtCash.Text.Trim(), out var temp) ? temp : 0m;
        var totalValue = investments.Sum(x => x.shares * x.price);
        
        foreach (var inv in investments)
        {
            var targetDollar = (inv.target / 100m) * totalValue;
            var currentDollar = inv.shares * inv.price;
            inv.dollarShortFall = targetDollar - currentDollar; // positive = underweight
        }
        var underweightInvestments = investments.Where(i => i.dollarShortFall > 0).ToList();
        var totalDollarShortfall = underweightInvestments.Sum(i => i.dollarShortFall);
        
        foreach (var inv in underweightInvestments)
        {
            // Allocate proportionally
            var allocatedDollar = totalDollarShortfall > 0
                ? inv.dollarShortFall / totalDollarShortfall * cashToAdd
                : 0;

            // Cap at exact shortfall
            allocatedDollar = Math.Min(allocatedDollar, inv.dollarShortFall);

            // Convert to whole shares, rounding down
            inv.sharesToAdd = (int)Math.Floor(allocatedDollar / inv.price);
            inv.dollarsToAdd = inv.sharesToAdd * inv.price;
        }
        var allocatedCash = underweightInvestments.Sum(i => i.dollarsToAdd);
        var leftoverCash = cashToAdd - allocatedCash;
        
        while (leftoverCash > 0)
        {
            // Get candidates: underweight positions that can accept at least one more share
            var candidates = underweightInvestments
                .Where(i => (i.dollarShortFall - i.dollarsToAdd) >= i.price)
                .OrderByDescending(i => i.dollarShortFall - i.dollarsToAdd)
                .ToList();

            if (candidates.Count == 0)
                break; // no more investments can accept leftover cash

            bool allocatedThisRound = false;

            foreach (var inv in candidates)
            {
                if (leftoverCash >= inv.price)
                {
                    inv.sharesToAdd += 1;
                    inv.dollarsToAdd += inv.price;
                    leftoverCash -= inv.price;
                    allocatedThisRound = true;
                }
            }

            if (!allocatedThisRound)
                break; // cannot allocate any more cash, exit safely
        }

    }
    
    private List<decimal> RebalanceWithOnlyCurrentShares(bool onlyToBands,  List<Investment> investments)
    {
        return null;
    }
}