using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using VitrineApi.Services.Interfaces;

namespace VitrineApi.Controllers;


[ApiController]
[Route("api/testing")]
public class TestingController(ITestingService testingService) : ControllerBase
{
    private readonly ITestingService _testingService = testingService;

    [HttpGet("user-story")]
    public async Task<ActionResult> GetUserStory()
    {
        var result = await _testingService.GetUserStoryAsync();
        return Ok(result.ToJson());
    }
}
