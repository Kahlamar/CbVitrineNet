using Newtonsoft.Json;


namespace CbVitrineNetClasses.Testing;

public class UserStory
{
    [JsonConstructor]
    public UserStory(string nomUs,
                     string risque,
                     string priorite,
                     string environnement,
                     string branche,
                     string descriptionDetaillee,
                     TestCase testCase)
    {
        NomUs = nomUs;
        Risque = risque;
        Priorite = priorite;
        Environnement = environnement;
        Branche = branche;
        DescriptionDetaillee = descriptionDetaillee;
        TestCaseValide = testCase;
    }

    [JsonProperty(nameof(NomUs))]
    public string NomUs { get; set; }

    [JsonProperty(nameof(Risque))]
    public string Risque { get; set; }

    [JsonProperty(nameof(Priorite))]
    public string Priorite { get; set; }

    [JsonProperty(nameof(Environnement))]
    public string Environnement { get; set; }

    [JsonProperty(nameof(Branche))]
    public string Branche { get; set; }

    [JsonProperty(nameof(DescriptionDetaillee))]
    public string DescriptionDetaillee { get; set; }

    [JsonProperty(nameof(TestCaseValide))]
    public TestCase TestCaseValide { get; set; }
}
