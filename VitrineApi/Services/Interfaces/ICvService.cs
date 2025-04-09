using MongoDB.Bson;

namespace VitrineApi.Services.Interfaces;

/// <summary>
/// Interface pour la création du service CV
/// </summary>
public interface ICvService
{
    /// <summary>
    /// Fonction de récupération de la liste de toutes les expériences
    /// </summary>
    /// <returns>Liste de toutes les expériences au format BSON</returns>
    Task<List<BsonDocument>> GetAllExperiencesAsync();

    /// <summary>
    /// Fonction de récupération de la liste de toutes les formations
    /// </summary>
    /// <returns>Liste de toutes les formations au format BSON</returns>
    Task<List<BsonDocument>> GetAllFormationsAsync();

    /// <summary>
    /// Fonction de récupération de la liste de toutes les certifications
    /// </summary>
    /// <returns>Liste de toutes les certifications au format BSON</returns>
    Task<List<BsonDocument>> GetAllCertificationsAsync();
}
