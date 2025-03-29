using Newtonsoft.Json;

namespace CbVitrineNetClasses.Testing;

public class TestCase
{
    [JsonConstructor]
    public TestCase(string prerequis,
                    List<EtapeTestCase> etapesTestCase)
    {
        Prerequis = prerequis;
        EtapesTestCase = etapesTestCase;
        _id = "1";
    }

    [JsonProperty("_id")]
    public object _id { get; set; }

    [JsonProperty("Prerequis")]
    public string Prerequis { get; set; }

    [JsonProperty("EtapesTestCase")]
    public List<EtapeTestCase> EtapesTestCase { get; set; }
}