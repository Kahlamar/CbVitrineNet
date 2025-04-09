using Newtonsoft.Json;

namespace CbVitrineNetClasses.Testing;


/// <summary>
/// Classe de base pour la déserialisation d'une étape d'un test case.
/// </summary>
public class EtapeTestCase
{

    /// <summary>
    /// Constructeur principal d'une étape d'un test case.
    /// </summary>
    /// <param name="numero">Numéro de l'étape</param>
    /// <param name="action">Action à effectuer dans cette étape</param>
    /// <param name="resultatAttendu">Résultat attendu à la suite de la réalisation de l'action</param>
    /// <param name="resultatObtenu">Résultat obtenu à l'issue de l'action</param>
    /// <param name="passFail">Statut Pass ou Fail</param>
    /// <param name="iD">Id de l'étape</param>
    [JsonConstructor]
    public EtapeTestCase(string numero,
                         string action,
                         string resultatAttendu,
                         string resultatObtenu,
                         string passFail,
                         string iD)
    {
        _id = iD;
        Numero = numero;
        Action = action;
        ResultatAttendu = resultatAttendu;
        ResultatObtenu = resultatObtenu;
        PassFail = passFail;
    }

    /// <summary>
    /// Id de l'étape du Test Case
    /// </summary>
    [JsonProperty(nameof(_id))]
    public object _id { get; set; }

    /// <summary>
    /// Numéro de l'étape du Test Case
    /// </summary>
    [JsonProperty(nameof(Numero))]
    public string Numero { get; set; }


    /// <summary>
    /// Action à réaliser
    /// </summary>
    [JsonProperty(nameof(Action))]
    public string Action { get; set; }

    /// <summary>
    /// Résultat attendu à la suite de la réalisation de l'action
    /// </summary>
    [JsonProperty(nameof(ResultatAttendu))]
    public string ResultatAttendu { get; set; }

    /// <summary>
    /// Résultat obtenu à l'issue de l'action
    /// </summary>
    [JsonProperty(nameof(ResultatObtenu))]
    public string ResultatObtenu { get; set; }

    /// <summary>
    /// Statut Pass ou Fail
    /// </summary>
    [JsonProperty(nameof(PassFail))]
    public string PassFail { get; set; }
}