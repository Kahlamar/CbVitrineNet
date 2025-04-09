using MongoDB.Bson;

namespace VitrineApi.Services.Interfaces;

/// <summary>
/// Interface pour la création du service Testing
/// </summary>
public interface ITestingService
{
    /// <summary>
    /// Fonction de récupération de l'US
    /// </summary>
    /// <returns>L'US au format BSON</returns>
    Task<BsonDocument> GetUserStoryAsync();
}
