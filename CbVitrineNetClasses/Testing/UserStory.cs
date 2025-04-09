using Newtonsoft.Json;


namespace CbVitrineNetClasses.Testing;

/// <summary>
/// Classe de base pour la déserialisation d'une User Story.
/// </summary>
public class UserStory
{
    /// <summary>
    /// Constructeur principal d'une User Story
    /// </summary>
    /// <param name="nomUs">Nom de l'User Story</param>
    /// <param name="risque">Risque de l'US</param>
    /// <param name="priorite">Priorité de l'US</param>
    /// <param name="environnement">Environnement de l'US</param>
    /// <param name="branche">Branche Git de l'US</param>
    /// <param name="descriptionDetaillee">Description de l'US</param>
    /// <param name="testCase">Test Case associé à l'US</param>
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

    /// <summary>
    /// Nom de l'US
    /// </summary>
    [JsonProperty(nameof(NomUs))]
    public string NomUs { get; set; }

    /// <summary>
    /// Risque de l'US
    /// </summary>
    [JsonProperty(nameof(Risque))]
    public string Risque { get; set; }

    /// <summary>
    /// Priorité de l'US
    /// </summary>
    [JsonProperty(nameof(Priorite))]
    public string Priorite { get; set; }

    /// <summary>
    /// Environnement de l'US
    /// </summary>
    [JsonProperty(nameof(Environnement))]
    public string Environnement { get; set; }

    /// <summary>
    /// Branche Git de l'US
    /// </summary>
    [JsonProperty(nameof(Branche))]
    public string Branche { get; set; }

    /// <summary>
    /// Description détaillée de l'US
    /// </summary>
    [JsonProperty(nameof(DescriptionDetaillee))]
    public string DescriptionDetaillee { get; set; }

    /// <summary>
    /// Test Case associé à l'US
    /// </summary>
    [JsonProperty(nameof(TestCaseValide))]
    public TestCase TestCaseValide { get; set; }
}
