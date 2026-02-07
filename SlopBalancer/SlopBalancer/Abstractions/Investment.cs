namespace SlopBalancer.Abstractions;

public class Investment
{
    public string ticker;
    public decimal shares;
    public decimal price;
    public int target;
    
    public decimal value;
    public decimal targetPercentage;
    
    public decimal offTargetPercentage;

    public decimal sharesToAdd;

    public Investment(string ticker, decimal shares, decimal price, int target)
    {
        this.ticker = ticker;
        this.shares = shares;
        this.price = price;
        this.target = target;

        value = shares * price;
        targetPercentage = target / 100m;
    }
    
    /// <summary>
    /// Certain inits should run once the coll is fully built (ex. things requiring totals of the entire coll)
    /// </summary>
    public void Initialize(decimal totalValue)
    {
        offTargetPercentage = value / totalValue - targetPercentage;
    }
}