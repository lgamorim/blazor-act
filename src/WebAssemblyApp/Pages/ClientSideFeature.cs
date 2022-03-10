using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;

namespace BlazorAct.WebAssemblyApp.Pages;

public partial class ClientSideFeature
{
    private IList<Tuple<string, string>> clientSideFeatures;

    [Inject]
    private HttpClient Http { get; set; }

    [Parameter]
    public int Index { get; set; }
    
    protected override async Task OnInitializedAsync()
    {
        clientSideFeatures = await Http.GetFromJsonAsync<IList<Tuple<string, string>>>("sample-data/ClientSide.json");
    }

    private Tuple<string, string> GetFeature(int index)
    {
        return clientSideFeatures?[index];
    }
}