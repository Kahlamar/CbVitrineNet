using Microsoft.AspNetCore.Mvc;
using VitrineApi.Services.Interfaces;
using MongoDB.Bson;

namespace VitrineApi.Controllers;


/// <summary>
/// Contrôleur Principal de la section CV
/// </summary>
/// <param name="cvService">Service CV</param>
[Route("api/cv")]
[ApiController]
public class CvController(ICvService cvService) : ControllerBase
{
    /// <summary>
    /// Affectation du service CV
    /// </summary>
    private readonly ICvService _cvService = cvService;

    /// <summary>
    /// Endpoint de récupérations de toutes les expériences.
    /// </summary>
    /// <returns>Liste de toutes les expériences</returns>
    [HttpGet("experiences")]
    public async Task<ActionResult> GetAllExperiences()
    {
        var result = await _cvService.GetAllExperiencesAsync();
        return Ok(result.ToJson());
    }

    /// <summary>
    /// Endpoint de récupérations de toutes les formations.
    /// </summary>
    /// <returns>Liste de toutes les formations</returns>
    [HttpGet("formations")]
    public async Task<ActionResult> GetAllFormations()
    {
        var result = await _cvService.GetAllFormationsAsync();
        return Ok(result.ToJson());
    }

    /// <summary>
    /// Endpoint de récupérations de toutes les certifications.
    /// </summary>
    /// <returns>Liste de toutes les certifications</returns>
    [HttpGet("certifications")]
    public async Task<ActionResult> GetAllCertifications()
    {
        var result = await _cvService.GetAllCertificationsAsync();
        return Ok(result.ToJson());
    }

}
