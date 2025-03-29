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

    [JsonProperty("_id")]
    public object _id { get; set; }

    [JsonProperty("Numero")]
    public string Numero { get; set; }

    [JsonProperty("Action")]
    public string Action { get; set; }

    [JsonProperty("ResultatAttendu")]
    public string ResultatAttendu { get; set; }

    [JsonProperty("ResultatObtenu")]
    public string ResultatObtenu { get; set; }

    [JsonProperty("PassFail")]
    public string PassFail { get; set; }
}