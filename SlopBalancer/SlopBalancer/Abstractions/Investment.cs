namespace SlopBalancer.Abstractions;

public class Investment
{
    public string ticker;
    public decimal shares;
    public decimal price;
    public int target;

    public decimal sharesToAdd;

    public Investment(string ticker, decimal shares, decimal price, int target)
    {
        this.ticker = ticker;
        this.shares = shares;
        this.price = price;
        this.target = target;
    }
}