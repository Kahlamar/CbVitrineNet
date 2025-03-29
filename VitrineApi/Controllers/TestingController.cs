using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace VitrineApi.Controllers;


[ApiController]
[Route("api/testing")]
public class TestingController(IMongoClient mongoClient) : ControllerBase
{
    private readonly IMongoDatabase _mongoClient = mongoClient.GetDatabase("VitrineNet");


    [HttpGet("user-story")]
    public async Task<ActionResult> GetUserStory()
    {
        IMongoCollection<BsonDocument> collection = _mongoClient.GetCollection<BsonDocument>("UserStories");
        var projection = Builders<BsonDocument>.Projection.Exclude("_id");
        BsonDocument userStory = await collection.Find(new BsonDocument()).Project(projection).FirstOrDefaultAsync();

        if (userStory == null)
        {
            return NotFound("Aucun document trouvé");
        }

        return Ok(userStory.ToJson());
    }
}
