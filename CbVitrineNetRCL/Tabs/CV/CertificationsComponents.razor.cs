using CbVitrineNetClasses.CV;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace CbVitrineNetRCL.Tabs.CV;

/// <summary>
/// Classe principale du composant Certification
/// </summary>
public partial class CertificationsComponents
{
    /// <summary>
    /// Injection du Client Http
    /// </summary>
    [Inject]
    public required HttpClient Http { get; set; }

    /// <summary>
    /// Liste des certifications renvoyées par l'API
    /// </summary>
    List<Certification>? Certifications { get; set; }


    /// <summary>
    /// Méthode Blazor par défaut.
    /// 
    /// Permet la récupération de la liste des certifications à afficher.
    /// 
    /// </summary>
    /// <returns>Task</returns>
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