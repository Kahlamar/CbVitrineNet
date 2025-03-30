using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace VitrineApi.Models.CV;

public class Experience
{
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

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? IdExperience { get; set; }
    public string DateDebut { get; set; }
    public string DateFin { get; set; }
    public string Poste { get; set; }
    public string Entreprise { get; set; }
    public string Emplacement { get; set; }
    public List<string> TachesEffectuees { get; set; }
}
