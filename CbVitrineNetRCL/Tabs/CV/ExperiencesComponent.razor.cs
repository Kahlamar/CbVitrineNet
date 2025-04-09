using CbVitrineNetClasses.CV;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace CbVitrineNetRCL.Tabs.CV;

/// <summary>
/// Classe principale du composant Experiences
/// </summary>
public partial class ExperiencesComponent
{
    /// <summary>
    /// Injection du Client Http
    /// </summary>
    [Inject]
    public required HttpClient Http { get; set; }

    /// <summary>
    /// Liste des expériences renvoyées par l'API
    /// </summary>
    List<Experience>? Experiences { get; set; }

    /// <summary>
    /// Méthode Blazor par défaut.
    /// 
    /// Permet la récupération de la liste des expériences à afficher.
    /// 
    /// </summary>
    /// <returns>Task</returns>
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