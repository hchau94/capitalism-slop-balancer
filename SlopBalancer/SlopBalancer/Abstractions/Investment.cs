namespace SlopBalancer.Abstractions;

public class Investment(string ticker, decimal shares, decimal price, int targetPercentage)
{
    public string Ticker { get; set; } = ticker;
    public decimal Shares { get; set; } = shares;
    public decimal Price { get; set; } = price;
    public int TargetPercentage { get; set; } = targetPercentage;
    public decimal RebalancedShares { get; set; }
    public decimal RebalancedPercentage { get; set; }
}