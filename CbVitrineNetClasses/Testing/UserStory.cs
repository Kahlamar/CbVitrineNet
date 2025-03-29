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

    [JsonProperty("NomUs")]
    public string NomUs { get; set; }

    [JsonProperty("Risque")]
    public string Risque { get; set; }

    [JsonProperty("Priorite")]
    public string Priorite { get; set; }

    [JsonProperty("Environnement")]
    public string Environnement { get; set; }

    [JsonProperty("Branche")]
    public string Branche { get; set; }

    [JsonProperty("DescriptionDetaillee")]
    public string DescriptionDetaillee { get; set; }

    [JsonProperty("TestCaseValide")]
    public TestCase TestCaseValide { get; set; }
}
