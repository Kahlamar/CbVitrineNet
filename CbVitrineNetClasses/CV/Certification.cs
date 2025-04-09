using Newtonsoft.Json;

namespace CbVitrineNetClasses.CV;


/// <summary>
/// Classe de base pour la déserialisation d'une certification.
/// </summary>
public class Certification
{
    /// <summary>
    /// Constructeur principal d'une certification.
    /// </summary>
    /// <param name="id">Id de la certification</param>
    /// <param name="titre">Titre de la certification</param>
    /// <param name="organismeCertifiant">Organisme délivrant la certification</param>
    /// <param name="dureeValiditeAnnees">Durée de validité de la certification</param>
    [JsonConstructor]
    public Certification(object id,
                         string titre,
                         string organismeCertifiant,
                         int dureeValiditeAnnees)
    {
        _id = id;
        Titre = titre;
        OrganismeCertifiant = organismeCertifiant;
        DureeValiditeAnnees = dureeValiditeAnnees;
    }

    /// <summary>
    /// Id de la certification
    /// </summary>
    [JsonProperty(nameof(_id))]
    public object _id { get; set; }

    /// <summary>
    /// Titre de la certification
    /// </summary>
    [JsonProperty(nameof(Titre))]
    public string Titre { get; set; }

    /// <summary>
    /// Organisme certifiant
    /// </summary>
    [JsonProperty(nameof(OrganismeCertifiant))]
    public string OrganismeCertifiant { get; set; }

    /// <summary>
    /// Durée de validité en années
    /// </summary>
    [JsonProperty(nameof(DureeValiditeAnnees))]
    public int DureeValiditeAnnees { get; set; }
}
