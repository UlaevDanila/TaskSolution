using StockMarketConnector.Entities;

namespace SolutionTask.Utils.StockMarketConnectors.BitfinexConnector.Rest;

public static class BitfinexRestMapper
{
    public static IEnumerable<Trade> ConvertToTrades(this IEnumerable<IEnumerable<float>> responseResult)
    {
        var trades = new List<Trade>();
        foreach (var oneTradeInfo in responseResult)
        {
            var tradeInfo = new List<float>();
            foreach (var tradeFields  in oneTradeInfo)
            {
                tradeInfo.Add(tradeFields);
            }
            trades.Add(new Trade(tradeInfo[0], tradeInfo[1], 
                tradeInfo[2], tradeInfo[3]));
        }
        return trades;
    }

    public static IEnumerable<Candle> ConvertToCandle(this IEnumerable<IEnumerable<float>> responseResult)
    {
        var candles = new List<Candle>();
        foreach (var oneCandleInfo in responseResult)
        {
            var candleInfo = new List<float>();
            foreach (var candleFields  in oneCandleInfo)
            {
                candleInfo.Add(candleFields);
            }
            candles.Add(new Candle(candleInfo[0], candleInfo[1], candleInfo[2], candleInfo[3], 
                                                                        candleInfo[4], candleInfo[5]));
        }
        return candles;
    }
    
    public static Ticker ConvertToTicker(this IEnumerable<float> responseResult)
    {
        var tickerFields = new List<float>();
        foreach (var i in responseResult)
        {
            tickerFields.Add(i);
        }
        return new Ticker(tickerFields[0], tickerFields[1], tickerFields[2], tickerFields[3],
                    tickerFields[4], tickerFields[5], tickerFields[6],
                        tickerFields[7], tickerFields[8], tickerFields[9]);
    }
}