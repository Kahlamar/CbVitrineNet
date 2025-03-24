using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using VitrineApi.Services;

namespace VitrineApi.Controllers;

[Route("api")]
[ApiController]
public class TestController(VitrineService vitrineService) : ControllerBase
{
    private readonly VitrineService _vitrineService = vitrineService;

    [HttpGet("test")]
    public async Task<IActionResult> TestAsync()
    {
        return Ok(await _vitrineService.GetBouchonnageAsync());
    }
}


