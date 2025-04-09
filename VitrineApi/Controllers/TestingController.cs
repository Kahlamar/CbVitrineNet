using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using VitrineApi.Services.Interfaces;

namespace VitrineApi.Controllers;

/// <summary>
/// Contrôleur Principal de la section Testing
/// </summary>
/// <param name="testingService">Service Testing</param>
[ApiController]
[Route("api/testing")]
public class TestingController(ITestingService testingService) : ControllerBase
{
    /// <summary>
    /// Affectation du service Testing
    /// </summary>
    private readonly ITestingService _testingService = testingService;

    /// <summary>
    /// Endpoint de récupérations de l'User Story.
    /// </summary>
    /// <returns>User Story</returns>
    [HttpGet("user-story")]
    public async Task<ActionResult> GetUserStory()
    {
        var result = await _testingService.GetUserStoryAsync();
        return Ok(result.ToJson());
    }
}
