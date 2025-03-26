using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using VitrineApi.Services.Interfaces;

namespace VitrineApi.Controllers;

[Route("api")]
[ApiController]
public class TestController(IVitrineService vitrineService,
                            IConnectionMultiplexer redis) : ControllerBase
{
    private readonly IVitrineService _vitrineService = vitrineService;
    private readonly IConnectionMultiplexer _redis = redis;

    [HttpGet("test")]
    public async Task<IActionResult> TestAsync()
    {
        return Ok(await _vitrineService.GetBouchonnageAsync());
    }

    [HttpGet("redis")]
    public async Task<IActionResult> TestRedisAsync()
    {
        var db = _redis.GetDatabase();
        await db.StringSetAsync("message", "Canard !!!!");
        var value = await db.StringGetAsync("message");
        return Content($"Valeur stockée dans Redis : {value}");
    }
}


