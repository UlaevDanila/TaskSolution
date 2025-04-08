using StockMarketConnector.Connectors.Rest;
using StockMarketConnector.Entities;
using Newtonsoft.Json;
namespace SolutionTask.Utils.StockMarketConnectors.BitfinexConnector.Rest;

public class BitfinexRestConnector(HttpClient httpClient) : IRestConnector
{
    private readonly string _baseAPIurl = "https://api-pub.bitfinex.com/v2/";

    public IEnumerable<Trade> GetTrade(string firstValueName, string secondValueName)
    {
        var apiEndpoint = $"{_baseAPIurl}/trades/t{firstValueName}{secondValueName}/hist";
        var response = httpClient.GetAsync(apiEndpoint);
        var jsonResult = response.Result.Content.ReadAsStringAsync();
        var deserializedJson = JsonConvert.DeserializeObject<IEnumerable<IEnumerable<float>>>(jsonResult.Result)!;
        return deserializedJson.ConvertToTrades();
    }
    
    public IEnumerable<Candle> GetCandles(string firstValueName, string secondValueName, string timePeriod)
    {
        var apiEndpoint = $"{_baseAPIurl}candles/trade%3A{timePeriod}%3At{firstValueName}{secondValueName}/hist";
        var response = httpClient.GetAsync(apiEndpoint);
        var jsonResult = response.Result.Content.ReadAsStringAsync();
        var deserializedJson = JsonConvert.DeserializeObject<IEnumerable<IEnumerable<float>>>(jsonResult.Result)!;
        return deserializedJson.ConvertToCandle();
    }
    
    public Ticker GetTicker(string firstValueName, string secondValueName)
    {
        var apiEndpoint = $"{_baseAPIurl}ticker/t{firstValueName}{secondValueName}";
        var response = httpClient.GetAsync(apiEndpoint);
        var jsonResult = response.Result.Content.ReadAsStringAsync();
        var deserializedJson = JsonConvert.DeserializeObject<IEnumerable<float>>(jsonResult.Result)!;
        return deserializedJson.ConvertToTicker();
    }
}