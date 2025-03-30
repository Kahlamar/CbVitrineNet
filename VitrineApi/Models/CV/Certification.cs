using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace VitrineApi.Models.CV;

public class Certification
{
    public Certification(string idCertification,
                         string titre,
                         string organismeCertifiant,
                         string dureeValiditeAnnees)
    {
        IdCertification = idCertification;
        Titre = titre;
        OrganismeCertifiant = organismeCertifiant;
        DureeValiditeAnnees = dureeValiditeAnnees;
    }

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? IdCertification { get; set; }
    public string Titre { get; set; }
    public string OrganismeCertifiant { get; set; }
    public string DureeValiditeAnnees { get; set; }
}
