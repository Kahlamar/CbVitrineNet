using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace VitrineApi.Models.Testing
{
    public class EtapeTestCase
    {
        public EtapeTestCase(string numero,
                             string action,
                             string resultatAttendu,
                             string resultatObtenu,
                             string passFail)
        {
            Numero = numero;
            Action = action;
            ResultatAttendu = resultatAttendu;
            ResultatObtenu = resultatObtenu;
            PassFail = passFail;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Numero { get; set; }
        public string Action { get; set; }
        public string ResultatAttendu { get; set; }
        public string ResultatObtenu { get; set; }
        public string PassFail { get; set; }

    }
}