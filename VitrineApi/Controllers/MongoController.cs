using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using StackExchange.Redis;
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
        IMongoCollection<BsonDocument> collection = _mongo.GetCollection<BsonDocument>("TestCollection");

        // Récupération du premier document trouvé dans la collection
        BsonDocument document = await collection.Find(new BsonDocument()).FirstOrDefaultAsync();

        if (document == null)
        {
            return NotFound("Aucun document trouvé");
        }

        return Ok(document.ToJson());
    }

    [HttpPost("test2")]
    public async Task<ActionResult> PostTest()
    {
        IMongoCollection<BsonDocument> collection = _mongo.GetCollection<BsonDocument>("TestCollection");

        BsonDocument command = new BsonDocument("hello", 1); // Un objet BsonDocument doit être créé pour insérer une commande
        BsonDocument result = await _mongo.RunCommandAsync<BsonDocument>(command); // Exécution de la commande







        await collection.InsertOneAsync(new BsonDocument {
            { "success", "Or not ?" }
        });
        return Ok("Document inséré avec succès !");
    }

    [HttpDelete("test3")]
    public async Task<ActionResult> DeleteTest()
    {
        IMongoCollection<BsonDocument> collection = _mongo.GetCollection<BsonDocument>("TestCollection");
        await collection.DeleteOneAsync(new BsonDocument {
           {"_id", "67e4088ef31d4dd7a453bb5e" }
        });
        return Ok("Document supprimé avec succès !");
    }

}
