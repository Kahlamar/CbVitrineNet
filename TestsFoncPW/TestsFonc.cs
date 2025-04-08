using Microsoft.Playwright;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace TestsFoncPW;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{

    readonly string prenom = "Jean";
    readonly string nom = "Dupont";
    readonly string mail = "jean@dupont.com";
    readonly string motDePasseValide = "MotDePasseValide1234!";


    [Test]
    public async Task TestFonctionnelTestCaseValide1()
    {
        await Page.GotoAsync("https://playwright.dev");

        // Expect a title "to contain" a substring.
        await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));

        // create a locator
        var getStarted = Page.Locator("text=Get Started");

        // Expect an attribute "to be strictly equal" to the value.
        await Expect(getStarted).ToHaveAttributeAsync("href", "/docs/intro");

        // Click the get started link.
        await getStarted.ClickAsync();

        // Expects the URL to contain intro.
        await Expect(Page).ToHaveURLAsync(new Regex(".*intro"));
    }

    [Test]
    public async Task TestFonctionnelTestCaseValideAsync()
    {
        await Page.GotoAsync("http://localhost:5000");
        await Page.GetByRole(AriaRole.Tab, new() { Name = "Testeur" }).ClickAsync();

        await Page.Locator("id=nom").FillAsync(nom); // ne remplit pas l'input
        await Expect(Page.Locator("id=nom")).ToHaveTextAsync(nom);

        await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
    }


}
