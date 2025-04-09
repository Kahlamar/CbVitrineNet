using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace VitrineApi.Models.Testing;


/// <summary>
/// Classe principale Étape d'une étape de Test Case (MongoDB)
/// </summary>
public class EtapeTestCase
{
    /// <summary>
    /// Constructeur principal d'une étape
    /// </summary>
    /// <param name="numero">Numéro de l'étape</param>
    /// <param name="action">Action à effectuer</param>
    /// <param name="resultatAttendu">Résultat attendu</param>
    /// <param name="resultatObtenu">Résultat obtenu</param>
    /// <param name="passFail">Pass ou fail</param>
    public EtapeTestCase(string numero,
                         string action,
                         string resultatAttendu,
                         string resultatObtenu,
                         string passFail)
    {
        Numero = numero;
        Action = action;
        ResultatAttendu = resultatAttendu;
        ResultatObtenu = resultatObtenu;
        PassFail = passFail;
    }

    /// <summary>
    /// Id de l'étape
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    /// <summary>
    /// Numéro de l'étape
    /// </summary>
    public string Numero { get; set; }

    /// <summary>
    /// Action à effectuer
    /// </summary>
    public string Action { get; set; }

    /// <summary>
    /// Résultat attendu
    /// </summary>
    public string ResultatAttendu { get; set; }

    /// <summary>
    /// Résultat obtenu
    /// </summary>
    public string ResultatObtenu { get; set; }


    /// <summary>
    /// Pass ou fail
    /// </summary>
    public string PassFail { get; set; }

}