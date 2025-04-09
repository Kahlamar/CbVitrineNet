using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace VitrineApi.Models.CV;


/// <summary>
/// Classe principale Formation (MongoDB)
/// </summary>
public class Formation
{
    /// <summary>
    /// Constructeur principal d'une formation
    /// </summary>
    /// <param name="idFormation">Id Formation</param>
    /// <param name="dateDebut">Date de début</param>
    /// <param name="dateFin">Date de fin</param>
    /// <param name="titre">Titre de la formation</param>
    /// <param name="organisme">Organisme formateur</param>
    /// <param name="emplacement">Emplacement</param>
    /// <param name="niveauAtteint">Niveau Atteint</param>
    /// <param name="cours">Cours</param>
    public Formation(string? idFormation,
                     string dateDebut,
                     string dateFin,
                     string titre,
                     string organisme,
                     string emplacement,
                     string niveauAtteint,
                     List<string> cours)
    {
        IdFormation = idFormation;
        DateDebut = dateDebut;
        DateFin = dateFin;
        Titre = titre;
        Organisme = organisme;
        Emplacement = emplacement;
        NiveauAtteint = niveauAtteint;
        Cours = cours;
    }

    /// <summary>
    /// Id de la Formation
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? IdFormation { get; set; }

    /// <summary>
    /// Date de début de la formation
    /// </summary>
    public string DateDebut { get; set; }

    /// <summary>
    /// Date de fin de la formation
    /// </summary>
    public string DateFin { get; set; }

    /// <summary>
    /// Titre de la formation
    /// </summary>
    public string Titre { get; set; }

    /// <summary>
    /// Organisme
    /// </summary>
    public string Organisme { get; set; }

    /// <summary>
    /// Emplacement
    /// </summary>
    public string Emplacement { get; set; }

    /// <summary>
    /// Niveau atteint
    /// </summary>
    public string NiveauAtteint { get; set; }

    /// <summary>
    /// Liste des cours enseignés
    /// </summary>
    public List<string> Cours { get; set; }
}
