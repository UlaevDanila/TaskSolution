using System.Text.Json;
using StockMarketConnector.Connectors.Rest;
using StockMarketConnector.Entities;

namespace SolutionTask.Utils.StockMarketConnectors.BitfinexConnector.Rest;

public class BitfinexRestConnector(HttpClient httpClient) : IRestConnector
{
    private readonly string _baseAPIurl = "https://api-pub.bitfinex.com/v2/";


    public IEnumerable<Trade> GetTrade(string firstValueName, string secondValueName)
    {
        var apiEndpoint = $"{_baseAPIurl}/trades/t{firstValueName}{secondValueName}/hist";
        var response = httpClient.GetAsync(apiEndpoint);
        var jsonResult = response.Result.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<IEnumerable<Trade>>(jsonResult.Result);
    }
    
    public IEnumerable<Candle> GetCandles(string firstValueName, string secondValueName, string timePeriod)
    {
        var apiEndpoint = $"{_baseAPIurl}/candles/trade/%3A{timePeriod}%3A{firstValueName}%3A{secondValueName}/hist";
        var response = httpClient.GetAsync(apiEndpoint);
        var jsonResult = response.Result.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<IEnumerable<Candle>>(jsonResult.Result);
    }
    
    public IEnumerable<Ticker> GetTicker(string firstValueName, string secondValueName)
    {
        var apiEndpoint = $"{_baseAPIurl}/ticker/t{firstValueName}{secondValueName}hist";
        var response = httpClient.GetAsync(apiEndpoint);
        var jsonResult = response.Result.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<IEnumerable<Ticker>>(jsonResult.Result);
    }
}