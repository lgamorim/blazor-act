using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;

namespace BlazorAct.WebAssemblyApp.Pages;

public partial class ClientSideFeature
{
    private Tuple<string, string> clientSideFeature;

    [Inject]
    private HttpClient Http { get; set; }

    [Parameter]
    public int Index { get; set; }
    
    protected override async Task OnInitializedAsync()
    {
        var clientSideFeatures = await Http.GetFromJsonAsync<IList<Tuple<string, string>>>("sample-data/ClientSide.json");
        clientSideFeature = clientSideFeatures?[Index];
    }
}