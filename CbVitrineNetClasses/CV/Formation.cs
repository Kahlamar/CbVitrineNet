using Newtonsoft.Json;

namespace CbVitrineNetClasses.CV;

public class Formation
{
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

    [JsonProperty(nameof(_id))]
    public object _id { get; set; }

    [JsonProperty(nameof(DateDebut))]
    public string DateDebut { get; set; }

    [JsonProperty(nameof(DateFin))]
    public string DateFin { get; set; }

    [JsonProperty(nameof(Titre))]
    public string Titre { get; set; }

    [JsonProperty(nameof(Organisme))]
    public string Organisme { get; set; }

    [JsonProperty(nameof(Emplacement))]
    public string Emplacement { get; set; }

    [JsonProperty(nameof(NiveauAtteint))]
    public string NiveauAtteint { get; set; }

    [JsonProperty(nameof(Cours))]
    List<string> Cours { get; set; }

}
