using System.Text.Json;
using BlazorAct.WebAssemblyApp.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorAct.WebAssemblyApp.Pages;

public partial class JavaScript
{
    private ElementReference interopChart;
    
    [Inject]
    private HttpClient Http { get; set; }
    
    [Inject]
    private IJSRuntime JS { get; set; }
    
    private async Task<MarketData> CallMarketChartApi(string coin, string currency)
    {
        var apiUrl = $"https://api.coingecko.com/api/v3/coins/{coin}/market_chart?vs_currency={currency}&days=30&interval=daily";
        var stream = await Http.GetStreamAsync(apiUrl);
        var data = await JsonSerializer.DeserializeAsync<MarketData>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        return data;
    }

    [JSInvokable]
    public async void GetMarketData(string coin, string currency)
    {
        var data = await CallMarketChartApi(coin, currency);
        var days = data.Prices.Select(price => DateTimeOffset.FromUnixTimeMilliseconds((long)price[0]).ToString("d")).ToList();
        var prices = data.Prices.Select(price => price[1]).ToList();

        await JS.InvokeVoidAsync("displayChart", interopChart, prices, days);
    }
    
    [JSInvokable]
    public async Task<bool> PingCoinGeckoApi()
    {
        const string apiUrl = "https://api.coingecko.com/api/v3/ping";
        var response = await Http.GetAsync(apiUrl);
        
        return response.IsSuccessStatusCode;
    }
}