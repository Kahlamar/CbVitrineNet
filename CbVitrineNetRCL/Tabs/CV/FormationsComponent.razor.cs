using CbVitrineNetClasses.CV;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace CbVitrineNetRCL.Tabs.CV;

public partial class FormationsComponent
{
    [Inject]
    public required HttpClient Http { get; set; }

    List<Formation>? Formations { get; set; }


    protected override async Task OnInitializedAsync()
    {
        try
        {
            Formations = JsonConvert.DeserializeObject<List<Formation>>(await Http.GetStringAsync("http://vitrineapi:8080/api/cv/formations"));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erreur ! " + ex);
        }
    }
}