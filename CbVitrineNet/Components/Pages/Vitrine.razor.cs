using Microsoft.AspNetCore.Components;
using static System.Net.WebRequestMethods;

namespace CbVitrineNet.Components.Pages;

public partial class Vitrine
{
    [Inject]
    public new HttpClient Http { get; set; }

    private List<string> testList;

    public async Task<List<string>> GetTestStrings(string url)
    {
        return await Http.GetFromJsonAsync<List<string>>(url);
    }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            testList = await GetTestStrings("http://vitrineapi:8080/api/test");

            foreach (var item in testList)
            {
                Console.WriteLine("Item : " + item);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erreur !");
        }
    }
}
