namespace StockMarketConnector.Entities;

public record Candle(int Mts, decimal Open, decimal Close, decimal High, decimal Low, decimal Volume);