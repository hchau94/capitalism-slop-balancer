namespace SlopBalancer.Abstractions;

public interface IView
{
    event EventHandler UpdateClicked;

    string GetTickers();
}