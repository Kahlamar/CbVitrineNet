using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace VitrineApi.Models.CV;

/// <summary>
/// Classe principale Certification (MongoDB)
/// </summary>
public class Certification
{
    /// <summary>
    /// Constructeur principal d'une certification
    /// </summary>
    /// <param name="idCertification">Id de la certification</param>
    /// <param name="titre">Titre de la certification</param>
    /// <param name="organismeCertifiant">Organisme certifiant</param>
    /// <param name="dureeValiditeAnnees">Durée de validitée en années</param>
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

    /// <summary>
    /// Id de la certification
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? IdCertification { get; set; }

    /// <summary>
    /// Titre de la certification
    /// </summary>
    public string Titre { get; set; }

    /// <summary>
    /// Organisme certifiant
    /// </summary>
    public string OrganismeCertifiant { get; set; }

    /// <summary>
    /// Durée de validité en années
    /// </summary>
    public string DureeValiditeAnnees { get; set; }
}
