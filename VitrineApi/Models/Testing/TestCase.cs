using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace VitrineApi.Models.Testing;

/// <summary>
/// Classe principale d'un Test Case (MongoDB)
/// </summary>
public class TestCase
{
    /// <summary>
    /// Constructeur principal
    /// </summary>
    /// <param name="prerequis">prérequis</param>
    /// <param name="etapesTestCase">Étapes du Test Case</param>
    public TestCase(string prerequis,
                    List<EtapeTestCase> etapesTestCase)
    {
        Id = "1";
        Prerequis = prerequis;
        EtapesTestCase = etapesTestCase;
    }

    /// <summary>
    /// Id du Test Case
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    /// <summary>
    /// Prérequis du Test Case
    /// </summary>
    public string Prerequis { get; set; }

    /// <summary>
    /// Liste des étapes du Test Case
    /// </summary>
    public List<EtapeTestCase> EtapesTestCase { get; set; }

}