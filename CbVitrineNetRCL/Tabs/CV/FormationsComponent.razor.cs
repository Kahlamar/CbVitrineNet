using CbVitrineNetClasses.CV;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace CbVitrineNetRCL.Tabs.CV;

/// <summary>
/// Classe principale du composant Formations
/// </summary>
public partial class FormationsComponent
{
    /// <summary>
    /// Injection du Client Http
    /// </summary>
    [Inject]
    public required HttpClient Http { get; set; }

    /// <summary>
    /// Liste des formations renvoyées par l'API
    /// </summary>
    List<Formation>? Formations { get; set; }

    /// <summary>
    /// Méthode Blazor par défaut.
    /// 
    /// Permet la récupération de la liste des formations à afficher.
    /// 
    /// </summary>
    /// <returns>Task</returns>
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