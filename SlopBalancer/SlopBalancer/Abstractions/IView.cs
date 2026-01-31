namespace SlopBalancer.Abstractions;

public interface IView
{
    event EventHandler BalanceClicked;

    string GetTickers();
}