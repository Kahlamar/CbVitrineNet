using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using VitrineApi.Models;
namespace VitrineApi.Controllers;

[ApiController]
[Route("mongo")]
public class MongoController(IMongoClient mongo) : ControllerBase
{
    private readonly IMongoDatabase _mongo = mongo.GetDatabase("TestNet");

    [HttpGet("test")]
    public async Task<ActionResult> GetTest()
    {
        var collection = _mongo.GetCollection<BsonDocument>("TestCollection");

        // Récupération du premier document trouvé dans la collection
        var document = await collection.Find(new BsonDocument()).FirstOrDefaultAsync();

        if (document == null)
        {
            return NotFound("Aucun document trouvé");
        }

        return Ok(document.ToJson());
    }
}
