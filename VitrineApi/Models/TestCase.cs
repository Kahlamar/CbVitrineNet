using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace VitrineApi.Models
{
    public class TestCase
    {
        public TestCase(string prerequis,
                        List<EtapeTestCase> etapesTestCase)
        {
            Id = "1";
            Prerequis = prerequis;
            EtapesTestCase = etapesTestCase;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Prerequis { get; set; }

        public List<EtapeTestCase> EtapesTestCase { get; set; }

    }
}