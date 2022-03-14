namespace BlazorAct.WebAssemblyApp.Models;

public class ClientSideFeatureDetail
{
    public string Feature { get; set; }
    public string Description { get; set; }
    public IList<string> Details { get; set; } = new List<string>();
}