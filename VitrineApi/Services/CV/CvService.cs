using MongoDB.Bson;
using MongoDB.Driver;
using VitrineApi.Services.Interfaces;

namespace VitrineApi.Services.CV;

/// <summary>
/// Service à destination de la section CV
/// </summary>
/// <param name="mongoClient">Client MongoDB</param>
public class CvService(IMongoClient mongoClient) : ICvService
{
    /// <summary>
    /// Affectation client MongoDB
    /// </summary>
    private readonly IMongoDatabase _mongoClient = mongoClient.GetDatabase("VitrineNet");

    /// <summary>
    /// Fonction de récupération de la liste de toutes les expériences
    /// </summary>
    /// <returns>Liste de toutes les expériences au format BSON</returns>
    public async Task<List<BsonDocument>> GetAllExperiencesAsync()
    {
        IMongoCollection<BsonDocument> collection = _mongoClient.GetCollection<BsonDocument>("Experiences");
        var projection = Builders<BsonDocument>.Projection.Exclude("_id");
        return await collection.Find(new BsonDocument()).Project(projection).ToListAsync();
    }

    /// <summary>
    /// Fonction de récupération de la liste de toutes les formations
    /// </summary>
    /// <returns>Liste de toutes les formations au format BSON</returns>
    public async Task<List<BsonDocument>> GetAllFormationsAsync()
    {
        IMongoCollection<BsonDocument> collection = _mongoClient.GetCollection<BsonDocument>("Formations");
        var projection = Builders<BsonDocument>.Projection.Exclude("_id");
        return await collection.Find(new BsonDocument()).Project(projection).ToListAsync();
    }

    /// <summary>
    /// Fonction de récupération de la liste de toutes les certifications
    /// </summary>
    /// <returns>Liste de toutes les certifications au format BSON</returns>
    public async Task<List<BsonDocument>> GetAllCertificationsAsync()
    {
        IMongoCollection<BsonDocument> collection = _mongoClient.GetCollection<BsonDocument>("Certifications");
        var projection = Builders<BsonDocument>.Projection.Exclude("_id");
        return await collection.Find(new BsonDocument()).Project(projection).ToListAsync();
    }

}

