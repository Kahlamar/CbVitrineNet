using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace VitrineApi.Models.Testing;

/// <summary>
/// Classe principale d'une User Story (MongoDB)
/// </summary>
public class UserStory
{
    /// <summary>
    /// Constrcteur principal d'une US
    /// </summary>
    /// <param name="nomUs">Nom de l'US</param>
    /// <param name="risque">Risque de l'US</param>
    /// <param name="priorite">Priorité de l'US</param>
    /// <param name="environnement">Environnement de l'US</param>
    /// <param name="branche">Branche de l'US</param>
    /// <param name="descriptionDetaillee">Description détaillée de l'US</param>
    /// <param name="testCase">Test Case associé</param>
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
    /// Id de l'US
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    /// <summary>
    /// Nom de l'US
    /// </summary>
    public string NomUs { get; set; }

    /// <summary>
    /// Risque de l'US
    /// </summary>
    public string Risque { get; set; }

    /// <summary>
    /// Pririté de l'US
    /// </summary>
    public string Priorite { get; set; }

    /// <summary>
    /// Environnement de l'US
    /// </summary>
    public string Environnement { get; set; }

    /// <summary>
    /// Branche de l,US
    /// </summary>
    public string Branche { get; set; }

    /// <summary>
    /// Description détaillée de l'US
    /// </summary>
    public string DescriptionDetaillee { get; set; }

    /// <summary>
    /// Test Case associé
    /// </summary>
    public TestCase TestCaseValide { get; set; }
}
