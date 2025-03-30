using Newtonsoft.Json;

namespace CbVitrineNetClasses.CV;

public class Certification
{
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

    [JsonProperty(nameof(_id))]
    public object _id { get; set; }

    [JsonProperty(nameof(Titre))]
    public string Titre { get; set; }

    [JsonProperty(nameof(OrganismeCertifiant))]
    public string OrganismeCertifiant { get; set; }

    [JsonProperty(nameof(DureeValiditeAnnees))]
    public int DureeValiditeAnnees { get; set; }
}
