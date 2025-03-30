using MongoDB.Bson;

namespace VitrineApi.Services.Interfaces;

public interface ITestingService
{
    Task<BsonDocument> GetUserStoryAsync();
}
