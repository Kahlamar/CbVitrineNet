using CbVitrineNetClasses.Testing;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;


namespace CbVitrineNetRCL.Tabs.Testing;

public partial class TestingComponent
{
    [Inject]
    public required HttpClient Http { get; set; }

    UserStory? UserStory { get; set; }

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