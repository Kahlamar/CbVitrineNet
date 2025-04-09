using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace VitrineApi.Models.CV;


/// <summary>
/// Classe principale Experience (MongoDB)
/// </summary>
public class Experience
{
    /// <summary>
    /// Constructeur principal d'une expérience
    /// </summary>
    /// <param name="idExperience">Id de l'expérience</param>
    /// <param name="dateDebut">Date de début de l'expérience</param>
    /// <param name="dateFin">Date de fin de l'expérience</param>
    /// <param name="poste">Poste occupé</param>
    /// <param name="entreprise">Entreprise occupé</param>
    /// <param name="emplacement">Emplacement</param>
    /// <param name="tachesEffectuees">Tâches effectuées</param>
    public Experience(string? idExperience,
                      string dateDebut,
                      string dateFin,
                      string poste,
                      string entreprise,
                      string emplacement,
                      List<string> tachesEffectuees)
    {
        IdExperience = idExperience;
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
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? IdExperience { get; set; }

    /// <summary>
    /// Date de début de l'expérience
    /// </summary>
    public string DateDebut { get; set; }

    /// <summary>
    /// Date de fin de l'expérience
    /// </summary>
    public string DateFin { get; set; }

    /// <summary>
    /// Poste occupé
    /// </summary>
    public string Poste { get; set; }

    /// <summary>
    /// Entreprise d'accueil
    /// </summary>
    public string Entreprise { get; set; }

    /// <summary>
    /// Emplacement
    /// </summary>
    public string Emplacement { get; set; }

    /// <summary>
    /// Liste des tâches effectuées
    /// </summary>
    public List<string> TachesEffectuees { get; set; }
}
