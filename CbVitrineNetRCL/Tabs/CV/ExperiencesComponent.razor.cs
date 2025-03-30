using CbVitrineNetClasses.CV;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace CbVitrineNetRCL.Tabs.CV;

public partial class ExperiencesComponent
{
    [Inject]
    public required HttpClient Http { get; set; }

    List<Experience>? Experiences { get; set; }


    protected override async Task OnInitializedAsync()
    {
        try
        {
            Experiences = JsonConvert.DeserializeObject<List<Experience>>(await Http.GetStringAsync("http://vitrineapi:8080/api/cv/experiences"));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erreur ! " + ex);
        }
    }
}