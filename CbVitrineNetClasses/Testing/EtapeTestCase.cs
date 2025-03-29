using Newtonsoft.Json;

namespace CbVitrineNetClasses.Testing;

public class EtapeTestCase
{

    [JsonConstructor]
    public EtapeTestCase(string numero,
                         string action,
                         string resultatAttendu,
                         string resultatObtenu,
                         string passFail,
                         string iD)
    {
        _id = iD;
        Numero = numero;
        Action = action;
        ResultatAttendu = resultatAttendu;
        ResultatObtenu = resultatObtenu;
        PassFail = passFail;
    }

    [JsonProperty(nameof(_id))]
    public object _id { get; set; }

    [JsonProperty(nameof(Numero))]
    public string Numero { get; set; }

    [JsonProperty(nameof(Action))]
    public string Action { get; set; }

    [JsonProperty(nameof(ResultatAttendu))]
    public string ResultatAttendu { get; set; }

    [JsonProperty(nameof(ResultatObtenu))]
    public string ResultatObtenu { get; set; }

    [JsonProperty(nameof(PassFail))]
    public string PassFail { get; set; }
}