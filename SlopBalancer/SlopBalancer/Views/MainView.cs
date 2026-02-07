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
        
        cmdRefresh.Click += ProcessMegaPaste;
        cmdRefresh.Click += MaybeEnableBalanceButton;

        txtMagic.TextChanged += ProcessMegaPaste;
        txtMagic.TextChanged += MaybeEnableBalanceButton;

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

    private void ProcessMegaPaste(object sender, EventArgs e)
    {
        var pastedRows = txtMagic.Text.Split("\r\n").ToList();
        var headers = pastedRows.First();
        if (pastedRows.Count <= 1 || string.IsNullOrWhiteSpace(headers)) return;

        var tickerIndex = headers.Split("\t").Select((value, i) => new { value, i }).FirstOrDefault(x => x.value == "Ticker")?.i ?? -1;
        var priceIndex = headers.Split("\t").Select((value, i) => new { value, i }).FirstOrDefault(x => x.value == "Price")?.i ?? -1;
        var sharesIndex = headers.Split("\t").Select((value, i) => new { value, i }).FirstOrDefault(x => x.value == "Shares")?.i ?? -1;
        var targetIndex = headers.Split("\t").Select((value, i) => new { value, i }).FirstOrDefault(x => x.value == "Target")?.i ?? -1;
        if (tickerIndex == -1) MessageBox.Show( "Make sure you pasted in col headers, and make sure you include Ticker", "Invalid Paste");;
        if (priceIndex == -1) MessageBox.Show( "Make sure you pasted in col headers, and make sure you include Price", "Invalid Paste");;
        if (sharesIndex == -1) MessageBox.Show("Make sure you pasted in col headers, and make sure you include Shares", "Invalid Paste");;
        if (targetIndex == -1) MessageBox.Show("Make sure you pasted in col headers, and make sure you include Target", "Invalid Paste");;
        if (tickerIndex == -1 || priceIndex == -1 || sharesIndex == -1 || targetIndex == -1) return;

        var tickers = new List<string>();
        var prices = new List<string>();
        var shares = new List<string>();
        var targets = new List<string>();
        foreach (var pastedRow in pastedRows.Skip(1))
        {
            var pastedRowValues = pastedRow.Split("\t");
            tickers.Add(pastedRowValues[tickerIndex]);
            prices.Add(pastedRowValues[priceIndex]);
            shares.Add(pastedRowValues[sharesIndex]);
            targets.Add(pastedRowValues[targetIndex]);
        }
        txtTickers.Text = string.Join("\r\n", tickers);
        txtPrices.Text = string.Join("\r\n", prices);
        txtCurrentShares.Text = string.Join("\r\n", shares);
        txtTargets.Text = string.Join("\r\n", targets);
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
        var totalValue = investments.Sum(x => x.value);
        foreach (var investment in investments)
        {
            investment.Initialize(totalValue);
        }

        if (radioAddCash.Checked)
        {
            if (string.IsNullOrWhiteSpace(txtCash.Text) || (decimal.TryParse(txtCash.Text.Trim(), out var temp) ? temp : 0m) == 0) RebalanceWithOnlyCurrentShares(chkOnlyToBands.Checked, investments);
            else RebalanceWithOnlyNewCash(investments);

        }
        else if (radioOnlyCurrent.Checked)
        {
            RebalanceWithOnlyCurrentShares(chkOnlyToBands.Checked, investments);
        }

        OutputRebalancedData(investments);
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

    private void RebalanceWithOnlyNewCash(List<Investment> investments)
    {
        // onlyToBands not needed because it should be going past bands to spend all cash anyways
        
        var cashToAdd = decimal.TryParse(txtCash.Text.Trim(), out var temp) ? temp : 0m;
        Investment lastBought = null;
        
        var mostUnderweight = investments.OrderBy(x => x.offTargetPercentage).ToList();
        while (mostUnderweight.Sum(x => x.sharesToAdd * x.price) <= cashToAdd)
        {
            if (mostUnderweight.Count == 0) break;
            
            lastBought = mostUnderweight.First();
            lastBought.sharesToAdd++;
            
            var newTotalValue = investments.Sum(x => x.value + (x.sharesToAdd * x.price));
            mostUnderweight = mostUnderweight.OrderBy(x => (x.value + (x.sharesToAdd * x.price)) / newTotalValue - x.targetPercentage).ToList();
        }
        
        // If last bought went too over budget, then fine tune below to better spend that last chunk of cash
        var spent = investments.Sum(x => x.sharesToAdd * x.price);
        var remainingCash = cashToAdd - spent;
        if (remainingCash < 0 && lastBought != null)
        {
            lastBought.sharesToAdd--;
            remainingCash += lastBought.price;
        }
        SpendRemainingCash(investments, remainingCash);
    }
    
    private void SpendRemainingCash(List<Investment> investments, decimal remainingCash)
    {
        if (remainingCash <= 0) return;

        var candidates = investments.Where(i => i.price <= remainingCash).OrderBy(i => i.price / Math.Max(0.0001m, Math.Abs(i.offTargetPercentage))).ToList();
        foreach (var inv in candidates)
        {
            while (inv.price <= remainingCash)
            {
                inv.sharesToAdd++;
                remainingCash -= inv.price;
            }
        }
    }
    
    private void RebalanceWithOnlyCurrentShares(bool onlyToBands,  List<Investment> investments)
    {
        if (investments.Count <=1) return;
        while (true)
        {
            var totalRebalancedValue = investments.Sum(x => x.value + (x.sharesToAdd * x.price));
            
            if (onlyToBands && 
                investments.All(x => ((x.value + (x.sharesToAdd * x.price)) / totalRebalancedValue - x.targetPercentage) >= -0.0175m) &&
                investments.All(x => ((x.value + (x.sharesToAdd * x.price)) / totalRebalancedValue - x.targetPercentage) <= 0.0175m))
                break;
            else if (investments.All(x => ((x.value + (x.sharesToAdd * x.price)) / totalRebalancedValue - x.targetPercentage) >= -0.005m) &&
                     investments.All(x => ((x.value + (x.sharesToAdd * x.price)) / totalRebalancedValue - x.targetPercentage) <= 0.005m))
                break;

            var underweight = investments.OrderBy(x => (x.value + (x.sharesToAdd * x.price)) / totalRebalancedValue - x.targetPercentage).First();
            var overweight = investments.OrderByDescending(x => (x.value + (x.sharesToAdd * x.price)) / totalRebalancedValue - x.targetPercentage).First();
            
            overweight.sharesToAdd--;

            var priceDiffMultiple = (int)(overweight.price / underweight.price);
            for (int i = 0; i < priceDiffMultiple; i++) underweight.sharesToAdd++;
        }
        
        // spend remaining cash by just calling the other rebalancing method
        if (investments.Any(x => x.sharesToAdd != 0)) RebalanceWithOnlyNewCash(investments);
    }

    private void OutputRebalancedData(List<Investment> investments)
    {
        if (txtOutput.Text != "") txtOutput.Text += "\r\n";
        foreach (var investment in investments)
        {
            var plusOrMinus = investment.sharesToAdd >= 0 ? "+" : ""; // negative int printed out already comes with a minus sign
            txtOutput.Text += $"{plusOrMinus}{investment.sharesToAdd}\t{investment.ticker}\r\n";
        }
        
        var cashToAdd = decimal.TryParse(txtCash.Text.Trim(), out var temp) ? temp : 0m;
        var totalValue = investments.Sum(x => x.value);
        var totalRebalancedValue = investments.Sum(x => (x.shares + x.sharesToAdd) * x.price);
        txtOutput.Text += $"{cashToAdd - (totalRebalancedValue - totalValue)}\tleftover cash";
        
        txtOutput.Text += "\r\nOR copy paste below:\r\n";
        foreach (var investment in investments)
        {
            txtOutput.Text += $"{investment.sharesToAdd}\r\n";
        }
    }
}