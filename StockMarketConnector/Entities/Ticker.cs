namespace StockMarketConnector.Entities;

public record Ticker(decimal Bid, decimal DailyChange, decimal LastPrice,
                        decimal Volume, decimal High, decimal Low);