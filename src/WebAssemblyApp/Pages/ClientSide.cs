using System.Net.Http.Json;
using BlazorAct.WebAssemblyApp.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorAct.WebAssemblyApp.Pages;

public partial class ClientSide
{
    private IList<ClientSideFeatureDetail> clientSideFeatures = new List<ClientSideFeatureDetail>();

    [Inject]
    private HttpClient Http { get; set; }

    protected override async Task OnInitializedAsync()
    {
        clientSideFeatures = await Http.GetFromJsonAsync<IList<ClientSideFeatureDetail>>("sample-data/ClientSide.json");
    }
}