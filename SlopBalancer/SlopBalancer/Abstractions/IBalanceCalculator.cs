namespace SlopBalancer.Abstractions;

public interface IBalanceCalculator
{
    void UpdateStartingData(List<string> tickers, List<decimal> shares, List<int> targetPercentages);
    List<Investment> GetRebalancedInvestments(bool addNewCash, bool useBands);
}