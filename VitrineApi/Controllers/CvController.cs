using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using VitrineApi.Classes.Dtos.CV;
using VitrineApi.Classes.CV;
using VitrineApi.Services.Interfaces;
using VitrineApi.Services;

namespace VitrineApi.Controllers;

[Route("cv")]
[ApiController]
public class CvController(IMapper mapper, ICvService cvService) : ControllerBase
{
    private readonly IMapper _mapper = mapper;
    private readonly ICvService _cvService = cvService;

    [HttpGet("experiences")]
    public async Task<List<ExperienceDto>> GetExperiencesAsync()
    {
        return _mapper.Map<List<ExperienceDto>>(await _cvService.GetExperiencesAsync());
    }
}
