using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace VitrineApi.Models.Testing
{
    public class UserStory
    {
        public UserStory(string nomUs,
                         string risque,
                         string priorite,
                         string environnement,
                         string branche,
                         string descriptionDetaillee,
                         TestCase testCase)
        {
            NomUs = nomUs;
            Risque = risque;
            Priorite = priorite;
            Environnement = environnement;
            Branche = branche;
            DescriptionDetaillee = descriptionDetaillee;
            TestCaseValide = testCase;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string NomUs { get; set; }
        public string Risque { get; set; }
        public string Priorite { get; set; }
        public string Environnement { get; set; }
        public string Branche { get; set; }
        public string DescriptionDetaillee { get; set; }
        public TestCase TestCaseValide { get; set; }
    }
}
