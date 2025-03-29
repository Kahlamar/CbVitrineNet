using CbVitrineNetClasses.Testing;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace CbVitrineNetRCL.Tabs.Testing;

public partial class TestingComponent
{
    [Inject]
    public new HttpClient Http { get; set; }

    UserStory userStory { get; set; }


    protected override async Task OnInitializedAsync()
    {
        try
        {

            userStory = await Http.GetFromJsonAsync<UserStory>("http://vitrineapi:8080/api/testing/user-story");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erreur ! " + ex);
        }
    }
}