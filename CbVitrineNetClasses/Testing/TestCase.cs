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

    [JsonProperty(nameof(_id))]
    public object _id { get; set; }

    [JsonProperty(nameof(Prerequis))]
    public string Prerequis { get; set; }

    [JsonProperty(nameof(EtapesTestCase))]
    public List<EtapeTestCase> EtapesTestCase { get; set; }
}