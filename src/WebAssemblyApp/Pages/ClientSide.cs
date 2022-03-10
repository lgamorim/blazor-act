using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;

namespace BlazorAct.WebAssemblyApp.Pages;

public partial class ClientSide
{
    private IList<Tuple<string, string>> clientSideFeatures = new List<Tuple<string, string>>();

    [Inject]
    private HttpClient Http { get; set; }

    protected override async Task OnInitializedAsync()
    {
        clientSideFeatures = await Http.GetFromJsonAsync<IList<Tuple<string, string>>>("sample-data/ClientSide.json");
    }
}