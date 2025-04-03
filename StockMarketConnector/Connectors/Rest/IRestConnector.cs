using StockMarketConnector.Entities;

namespace StockMarketConnector.Connectors.Rest;

public interface IRestConnector
{
    public Task<Trade> GetTrade(string firstValueName, string secondValueName);

    public Task<Candle> GetCandles(string firstValueName, string secondValueName);

    public Task<Ticker> GetTicker(string tickerName);
}