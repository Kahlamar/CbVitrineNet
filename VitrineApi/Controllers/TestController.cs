using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using VitrineApi.Services;
using VitrineApi.Services.Interfaces;

namespace VitrineApi.Controllers;

[Route("api")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly IVitrineService _vitrineService;

    public TestController(IVitrineService vitrineService)
    {
        _vitrineService = vitrineService;
    }

    [HttpGet("test")]
    public async Task<IActionResult> TestAsync()
    {
        return Ok(await _vitrineService.GetBouchonnageAsync());
    }
}


