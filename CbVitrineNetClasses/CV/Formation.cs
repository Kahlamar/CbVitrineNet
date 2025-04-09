using Newtonsoft.Json;

namespace CbVitrineNetClasses.CV;

/// <summary>
/// Classe de base pour la déserialisation d'une formation.
/// </summary>
public class Formation
{
    /// <summary>
    /// Constructeur principal d'une formation.
    /// </summary>
    /// <param name="id">Id de la formation</param>
    /// <param name="dateDebut">Date de début de la formation</param>
    /// <param name="dateFin">Date de fin de la formation</param>
    /// <param name="titre">Titre de la formation</param>
    /// <param name="organisme">Organisme de la formation</param>
    /// <param name="emplacement">Emplacement de la formation</param>
    /// <param name="niveauAtteint">Niveau atteint à l'issue de la formation</param>
    /// <param name="cours">Liste des cours enseignés</param>
    [JsonConstructor]
    public Formation(object id,
                     string dateDebut,
                     string dateFin,
                     string titre,
                     string organisme,
                     string emplacement,
                     string niveauAtteint,
                     List<string> cours)
    {
        _id = id;
        DateDebut = dateDebut;
        DateFin = dateFin;
        Titre = titre;
        Organisme = organisme;
        Emplacement = emplacement;
        NiveauAtteint = niveauAtteint;
        Cours = cours;
    }

    /// <summary>
    /// Id de la formation
    /// </summary>
    [JsonProperty(nameof(_id))]
    public object _id { get; set; }

    /// <summary>
    /// Date de début de la formation
    /// </summary>
    [JsonProperty(nameof(DateDebut))]
    public string DateDebut { get; set; }

    /// <summary>
    /// Date de fin de la formation
    /// </summary>
    [JsonProperty(nameof(DateFin))]
    public string DateFin { get; set; }

    /// <summary>
    /// Titre de la formation
    /// </summary>
    [JsonProperty(nameof(Titre))]
    public string Titre { get; set; }

    /// <summary>
    /// Organisme formateur
    /// </summary>
    [JsonProperty(nameof(Organisme))]
    public string Organisme { get; set; }

    /// <summary>
    /// Emplacement de la formation
    /// </summary>
    [JsonProperty(nameof(Emplacement))]
    public string Emplacement { get; set; }

    /// <summary>
    /// Niveau atteint à la fin de la formation
    /// </summary>
    [JsonProperty(nameof(NiveauAtteint))]
    public string NiveauAtteint { get; set; }


    /// <summary>
    /// Liste des cours de la formation
    /// </summary>
    [JsonProperty(nameof(Cours))]
    public List<string> Cours { get; set; }

}
