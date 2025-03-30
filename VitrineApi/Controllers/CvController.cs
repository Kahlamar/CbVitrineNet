using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using VitrineApi.Classes.Dtos.CV;
using VitrineApi.Classes.CV;
using VitrineApi.Services.Interfaces;
using VitrineApi.Services;
using MongoDB.Bson;
using MongoDB.Driver;

namespace VitrineApi.Controllers;

[Route("api/cv")]
[ApiController]
public class CvController(ICvService cvService) : ControllerBase
{
    private readonly ICvService _cvService = cvService;

    [HttpGet("experiences")]
    public async Task<ActionResult> GetAllExperiences()
    {
        var result = await _cvService.GetAllExperiencesAsync();
        return Ok(result.ToJson());
    }

    [HttpGet("formations")]
    public async Task<ActionResult> GetAllFormations()
    {
        var result = await _cvService.GetAllFormationsAsync();
        return Ok(result.ToJson());
    }

    [HttpGet("certifications")]
    public async Task<ActionResult> GetAllCertifications()
    {
        var result = await _cvService.GetAllCertificationsAsync();
        return Ok(result.ToJson());
    }

}
