using CbVitrineNetClasses.CV;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace CbVitrineNetRCL.Tabs.CV;

public partial class CertificationsComponents
{
    [Inject]
    public required HttpClient Http { get; set; }

    List<Certification>? Certifications { get; set; }


    protected override async Task OnInitializedAsync()
    {
        try
        {
            Certifications = JsonConvert.DeserializeObject<List<Certification>>(await Http.GetStringAsync("http://vitrineapi:8080/api/cv/certifications"));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erreur ! " + ex);
        }
    }
}