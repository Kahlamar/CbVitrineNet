using CbVitrineNetClasses.CV;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace CbVitrineNetRCL.Tabs.CV;

public partial class ExperiencesComponent
{
    [Inject]
    public new HttpClient Http { get; set; }

    List<Experience> experiences { get; set; }


    protected override async Task OnInitializedAsync()
    {
        try
        {
            experiences = JsonConvert.DeserializeObject<List<Experience>>(await Http.GetStringAsync("http://vitrineapi:8080/api/cv/experiences"));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erreur ! " + ex);
        }
    }
}