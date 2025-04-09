using MongoDB.Bson;
using MongoDB.Driver;
using VitrineApi.Services.Interfaces;

namespace VitrineApi.Services.Testing;

/// <summary>
/// Service à destination de la section Testing
/// </summary>
/// <param name="mongoClient">Client MongoDB</param>
public class TestingService(IMongoClient mongoClient) : ITestingService
{
    /// <summary>
    /// Affectation client MongoDB
    /// </summary>
    private readonly IMongoDatabase _mongoClient = mongoClient.GetDatabase("VitrineNet");

    /// <summary>
    /// Fonction de récupération de l'User Story
    /// </summary>
    /// <returns>L'User Story au format BSON</returns>
    public async Task<BsonDocument> GetUserStoryAsync()
    {
        IMongoCollection<BsonDocument> collection = _mongoClient.GetCollection<BsonDocument>("UserStories");
        var projection = Builders<BsonDocument>.Projection.Exclude("_id");
        return await collection.Find(new BsonDocument()).Project(projection).FirstOrDefaultAsync();
    }
}
