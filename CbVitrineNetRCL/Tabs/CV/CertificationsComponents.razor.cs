using CbVitrineNetClasses.CV;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace CbVitrineNetRCL.Tabs.CV;

public partial class CertificationsComponents
{
    [Inject]
    public new HttpClient Http { get; set; }

    List<Certification> certifications { get; set; }


    protected override async Task OnInitializedAsync()
    {
        try
        {
            certifications = JsonConvert.DeserializeObject<List<Certification>>(await Http.GetStringAsync("http://vitrineapi:8080/api/cv/certifications"));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erreur ! " + ex);
        }
    }
}