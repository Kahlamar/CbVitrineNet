﻿using Newtonsoft.Json;

namespace CbVitrineNetClasses.CV;

public class Experience
{
    [JsonConstructor]
    public Experience(object id,
                      string dateDebut,
                      string dateFin,
                      string poste,
                      string entreprise,
                      string emplacement,
                      List<string> tachesEffectuees)
    {
        _id = id;
        DateDebut = dateDebut;
        DateFin = dateFin;
        Poste = poste;
        Entreprise = entreprise;
        Emplacement = emplacement;
        TachesEffectuees = tachesEffectuees;
    }

    [JsonProperty(nameof(_id))]
    public object _id { get; set; }

    [JsonProperty(nameof(DateDebut))]
    public string DateDebut { get; set; }

    [JsonProperty(nameof(DateFin))]
    public string DateFin { get; set; }

    [JsonProperty(nameof(Poste))]
    public string Poste { get; set; }

    [JsonProperty(nameof(Entreprise))]
    public string Entreprise { get; set; }

    [JsonProperty(nameof(Emplacement))]
    public string Emplacement { get; set; }

    [JsonProperty(nameof(TachesEffectuees))]
    public List<string> TachesEffectuees { get; set; }
}
