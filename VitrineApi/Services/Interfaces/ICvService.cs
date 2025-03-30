using MongoDB.Bson;

namespace VitrineApi.Services.Interfaces;

public interface ICvService
{
    Task<List<BsonDocument>> GetAllExperiencesAsync();
    Task<List<BsonDocument>> GetAllFormationsAsync();
    Task<List<BsonDocument>> GetAllCertificationsAsync();
}
