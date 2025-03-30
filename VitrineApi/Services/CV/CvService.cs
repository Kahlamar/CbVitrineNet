using MongoDB.Bson;
using MongoDB.Driver;
using VitrineApi.Services.Interfaces;

namespace VitrineApi.Services.CV;

public class CvService(IMongoClient mongoClient) : ICvService
{
    private readonly IMongoDatabase _mongoClient = mongoClient.GetDatabase("VitrineNet");

    public async Task<List<BsonDocument>> GetAllExperiencesAsync()
    {
        IMongoCollection<BsonDocument> collection = _mongoClient.GetCollection<BsonDocument>("Experiences");
        var projection = Builders<BsonDocument>.Projection.Exclude("_id");
        return await collection.Find(new BsonDocument()).Project(projection).ToListAsync();
    }

    public async Task<List<BsonDocument>> GetAllFormationsAsync()
    {
        IMongoCollection<BsonDocument> collection = _mongoClient.GetCollection<BsonDocument>("Formations");
        var projection = Builders<BsonDocument>.Projection.Exclude("_id");
        return await collection.Find(new BsonDocument()).Project(projection).ToListAsync();
    }

    public async Task<List<BsonDocument>> GetAllCertificationsAsync()
    {
        IMongoCollection<BsonDocument> collection = _mongoClient.GetCollection<BsonDocument>("Certifications");
        var projection = Builders<BsonDocument>.Projection.Exclude("_id");
        return await collection.Find(new BsonDocument()).Project(projection).ToListAsync();
    }

}

