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