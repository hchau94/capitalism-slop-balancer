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

        txtMagic.TextChanged += ProcessMegaPaste;

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
        var tickerIndex = headers.Split("\t").Select((value, i) => new { value, i }).FirstOrDefault(x => x.value == "Ticker")?.i ?? -1;
        var priceIndex = headers.Split("\t").Select((value, i) => new { value, i }).FirstOrDefault(x => x.value == "Price")?.i ?? -1;
        var sharesIndex = headers.Split("\t").Select((value, i) => new { value, i }).FirstOrDefault(x => x.value == "Shares")?.i ?? -1;
        var targetIndex = headers.Split("\t").Select((value, i) => new { value, i }).FirstOrDefault(x => x.value == "Target")?.i ?? -1;
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

        if (radioAddCash.Checked)
        {
            if (string.IsNullOrWhiteSpace(txtCash.Text)) RebalanceWithOnlyCurrentShares(chkOnlyToBands.Checked, investments);
            RebalanceWithOnlyNewCash(chkOnlyToBands.Checked, investments);

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

    private void RebalanceWithOnlyNewCash(bool onlyToBands, List<Investment> investments)
    {
        var cashToAdd = decimal.TryParse(txtCash.Text.Trim(), out var temp) ? temp : 0m;
        var totalValue = investments.Sum(x => x.shares * x.price);

        var obviouslyNeedMoreShares = investments.Where(x => ((x.shares * x.price)/totalValue) - (x.target / 100m) < -0.02m).ToList();
    }

    private List<decimal> RebalanceWithOnlyCurrentShares(bool onlyToBands,  List<Investment> investments)
    {
        return null;
    }

    private void OutputRebalancedData(List<Investment> investments)
    {
        foreach (var investment in investments)
        {
            txtOutput.Text += $"{investment.ticker} should get {investment.sharesToAdd} more shares.\r\n";
        }
        
        var cashToAdd = decimal.TryParse(txtCash.Text.Trim(), out var temp) ? temp : 0m;
        var totalValue = investments.Sum(x => x.shares * x.price);
        var totalRebalancedValue = investments.Sum(x => (x.shares + x.sharesToAdd) * x.price);
        txtOutput.Text += $"Leftover cash: {cashToAdd - (totalRebalancedValue - totalValue)}";
    }
}