using Newtonsoft.Json;

namespace CbVitrineNetClasses.CV;

/// <summary>
/// Classe de base pour la déserialisation d'une expérience.
/// </summary>
public class Experience
{
    /// <summary>
    /// Constructeur principal d'une expérience.
    /// </summary>
    /// <param name="id">Id de l'expérience</param>
    /// <param name="dateDebut">Date de début de l'expérience</param>
    /// <param name="dateFin">Date de fin de l'expérience</param>
    /// <param name="poste">Nom du poste au sein de l'entreprise</param>
    /// <param name="entreprise">Nom de l'entreprise</param>
    /// <param name="emplacement">Emplacement (Ville) de l'entreprise</param>
    /// <param name="tachesEffectuees">Liste des tâches effectuées lors de cette expérience</param>
    [JsonConstructor]
    public Experience(object id,
                      string dateDebut,
                      string dateFin,
                      string poste,
                      string entreprise,
                      string emplacement,
                      List<string> tachesEffectuees)
    {
        _id = id;
        DateDebut = dateDebut;
        DateFin = dateFin;
        Poste = poste;
        Entreprise = entreprise;
        Emplacement = emplacement;
        TachesEffectuees = tachesEffectuees;
    }

    /// <summary>
    /// Id de l'expérience
    /// </summary>
    [JsonProperty(nameof(_id))]
    public object _id { get; set; }

    /// <summary>
    /// Date de prise de poste
    /// </summary>
    [JsonProperty(nameof(DateDebut))]
    public string DateDebut { get; set; }


    /// <summary>
    /// Date de fin de contrat
    /// </summary>
    [JsonProperty(nameof(DateFin))]
    public string DateFin { get; set; }

    /// <summary>
    /// Nom du poste au sein de l'entreprise
    /// </summary>
    [JsonProperty(nameof(Poste))]
    public string Poste { get; set; }

    /// <summary>
    /// Entreprise d'accueil
    /// </summary>
    [JsonProperty(nameof(Entreprise))]
    public string Entreprise { get; set; }

    /// <summary>
    /// Emplacement de l'expérience
    /// </summary>
    [JsonProperty(nameof(Emplacement))]
    public string Emplacement { get; set; }


    /// <summary>
    /// Liste des tâches effectuées au sein de l'entreprise pour le poste
    /// </summary>
    [JsonProperty(nameof(TachesEffectuees))]
    public List<string> TachesEffectuees { get; set; }
}
