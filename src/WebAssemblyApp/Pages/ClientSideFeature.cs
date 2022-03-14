using System.Net.Http.Json;
using BlazorAct.WebAssemblyApp.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorAct.WebAssemblyApp.Pages;

public partial class ClientSideFeature
{
    private ClientSideFeatureDetail clientSideFeature;

    [Inject]
    private HttpClient Http { get; set; }

    [Parameter]
    public int Index { get; set; }
    
    protected override async Task OnInitializedAsync()
    {
        var clientSideFeatures = await Http.GetFromJsonAsync<IList<ClientSideFeatureDetail>>("sample-data/ClientSide.json");
        clientSideFeature = clientSideFeatures?[Index];
    }

    private MarkupString GetDescription(int index)
    {
        return new MarkupString(clientSideFeature?.Details?[index] ?? string.Empty);
    }
}