using Microsoft.AspNetCore.Mvc;
using SolutionTask.Utils.StockMarketConnectors.BitfinexConnector.Rest;
using StockMarketConnector.Connectors.Rest;
using StockMarketConnector.Entities;

namespace SolutionTask.Controllers;

public class RestApiController(HttpClient httpClient) : Controller
{
    private readonly IRestConnector _apiConnector = new BitfinexRestConnector(httpClient);

    public IEnumerable<Trade> GetTrades(string firstName, string secondName)
    {
        return _apiConnector.GetTrade(firstName, secondName);
    }

    public IEnumerable<Candle> GetCandles(string firstValue, string secondValue, string timePeriod)
    {
        return _apiConnector.GetCandles(firstValue, secondValue, timePeriod);
    }
    
    public Ticker GetTicker(string firstName, string secondName)
    {
        return _apiConnector.GetTicker(firstName, secondName);
    }
}