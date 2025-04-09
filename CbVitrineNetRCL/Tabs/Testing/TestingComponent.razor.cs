using CbVitrineNetClasses.Testing;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;


namespace CbVitrineNetRCL.Tabs.Testing;

/// <summary>
/// Classe principale du composant Testing
/// </summary>
public partial class TestingComponent
{
    /// <summary>
    /// Injection du Client Http
    /// </summary>
    [Inject]
    public required HttpClient Http { get; set; }

    /// <summary>
    /// User Story renvoyée par l'API
    /// </summary>
    UserStory? UserStory { get; set; }

    /// <summary>
    /// Méthode Blazor par défaut.
    /// 
    /// Permet la récupération de l'US à afficher.
    /// 
    /// </summary>
    /// <returns>Task</returns>
    protected override async Task OnInitializedAsync()
    {
        try
        {
            UserStory = JsonConvert.DeserializeObject<UserStory>(await Http.GetStringAsync("http://vitrineapi:8080/api/testing/user-story"));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erreur ! " + ex);
        }
    }
}