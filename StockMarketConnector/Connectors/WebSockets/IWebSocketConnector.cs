using StockMarketConnector.Entities;

namespace StockMarketConnector.Connectors.WebSockets;

public interface IWebSocketConnector
{
    public Task<Trade> GetTrade(string firstValueName, string secondValueName);

    public Task<Candle> GetCandle(string firstValueName, string secondValueName);
}