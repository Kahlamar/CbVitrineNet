using MongoDB.Bson;
using MongoDB.Driver;
using VitrineApi.Services.Interfaces;

namespace VitrineApi.Services.Testing
{
    public class TestingService(IMongoClient mongoClient) : ITestingService
    {
        private readonly IMongoDatabase _mongoClient = mongoClient.GetDatabase("VitrineNet");

        public async Task<BsonDocument> GetUserStoryAsync()
        {
            IMongoCollection<BsonDocument> collection = _mongoClient.GetCollection<BsonDocument>("UserStories");
            var projection = Builders<BsonDocument>.Projection.Exclude("_id");
            return await collection.Find(new BsonDocument()).Project(projection).FirstOrDefaultAsync();
        }
    }
}
