using System.Text.Json.Serialization;

namespace BlazorAct.WebAssemblyApp.Models;

public class MarketData
{
    public IList<IList<double>> Prices { get; set; }
    
    [JsonPropertyName("market_caps")]
    public IList<IList<double>> MarketCaps { get; set; }
    
    [JsonPropertyName("total_volumes")]
    public IList<IList<double>> TotalVolumes { get; set; }
}