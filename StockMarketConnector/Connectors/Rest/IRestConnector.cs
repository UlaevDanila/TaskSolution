using StockMarketConnector.Entities;

namespace StockMarketConnector.Connectors.Rest;

public interface IRestConnector
{
    public IEnumerable<Trade> GetTrade(string firstValueName, string secondValueName);

    public IEnumerable<Candle> GetCandles(string firstValueName, string secondValueName, string timePeriod);

    public Ticker GetTicker(string firstValueName, string secondValueName);
}