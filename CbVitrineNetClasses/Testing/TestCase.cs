using Newtonsoft.Json;

namespace CbVitrineNetClasses.Testing;

/// <summary>
/// Classe de base pour la déserialisation d'un test case.
/// </summary>
public class TestCase
{
    /// <summary>
    /// Constructeur principal d'un Test Case.
    /// </summary>
    /// <param name="prerequis">Prérequis nécessaires pour la réalisation du Test Case</param>
    /// <param name="etapesTestCase">Liste des Étapes (Classe EtapteTestCase) du Test Case</param>
    [JsonConstructor]
    public TestCase(string prerequis,
                    List<EtapeTestCase> etapesTestCase)
    {
        Prerequis = prerequis;
        EtapesTestCase = etapesTestCase;
        _id = "1";
    }

    /// <summary>
    /// Id du Test Case
    /// </summary>
    [JsonProperty(nameof(_id))]
    public object _id { get; set; }

    /// <summary>
    /// Prérequis nécessaires pour la réalisation du Test Case
    /// </summary>
    [JsonProperty(nameof(Prerequis))]
    public string Prerequis { get; set; }

    /// <summary>
    /// Liste des Étapes (EtapeTestCase) du Test Case
    /// </summary>
    [JsonProperty(nameof(EtapesTestCase))]
    public List<EtapeTestCase> EtapesTestCase { get; set; }
}