namespace StockMarketConnector.Entities;

public record Ticker(float Bid, float BidSize, float LowestAsk, float AskSize, float DailyChange, 
                        float DailyChangeRelative, float LastPrice, float Volume, float High, float Low);