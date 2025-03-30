using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using VitrineApi.Classes.Dtos.CV;
using VitrineApi.Classes.CV;
using VitrineApi.Services.Interfaces;
using VitrineApi.Services;
using MongoDB.Bson;
using MongoDB.Driver;

namespace VitrineApi.Controllers;

[Route("api/cv")]
[ApiController]
public class CvController(IMongoClient mongoClient) : ControllerBase
{
    private readonly IMongoDatabase _mongoClient = mongoClient.GetDatabase("VitrineNet");

    [HttpGet("experiences")]
    public async Task<ActionResult> GetAllExperiences()
    {
        IMongoCollection<BsonDocument> collection = _mongoClient.GetCollection<BsonDocument>("Experiences");
        var projection = Builders<BsonDocument>.Projection.Exclude("_id");
        List<BsonDocument> experiences = await collection.Find(new BsonDocument()).Project(projection).ToListAsync();

        if (experiences == null)
        {
            return NotFound("Aucun document trouvé");
        }

        return Ok(experiences.ToJson());
    }

    [HttpGet("formations")]
    public async Task<ActionResult> GetAllFormations()
    {
        IMongoCollection<BsonDocument> collection = _mongoClient.GetCollection<BsonDocument>("Formations");
        var projection = Builders<BsonDocument>.Projection.Exclude("_id");
        List<BsonDocument> formations = await collection.Find(new BsonDocument()).Project(projection).ToListAsync();

        if (formations == null)
        {
            return NotFound("Aucun document trouvé");
        }

        return Ok(formations.ToJson());
    }

    [HttpGet("certifications")]
    public async Task<ActionResult> GetAllCertifications()
    {
        IMongoCollection<BsonDocument> collection = _mongoClient.GetCollection<BsonDocument>("Certifications");
        var projection = Builders<BsonDocument>.Projection.Exclude("_id");
        List<BsonDocument> certifications = await collection.Find(new BsonDocument()).Project(projection).ToListAsync();

        if (certifications == null)
        {
            return NotFound("Aucun document trouvé");
        }

        return Ok(certifications.ToJson());
    }

}
