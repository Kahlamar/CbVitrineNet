using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace VitrineApi.Models.CV;

public class Formation
{
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

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? IdFormation { get; set; }
    public string DateDebut { get; set; }
    public string DateFin { get; set; }
    public string Titre { get; set; }
    public string Organisme { get; set; }
    public string Emplacement { get; set; }
    public string NiveauAtteint { get; set; }
    public List<string> Cours { get; set; }
}
