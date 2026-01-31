namespace SlopBalancer.Abstractions;

public interface IView
{
    bool AddNewCash { get; set; }
    bool UseCurrentSharesOnly { get; set; }
    bool RebalanceOnlyToBands { get; set; }
    
    string Tickers { get; set; }
    string CurrentShares { get; set; }
    string Targets { get; set; }
    string NewCashToAdd { get; set; }
    
    event EventHandler BalanceClicked;
}