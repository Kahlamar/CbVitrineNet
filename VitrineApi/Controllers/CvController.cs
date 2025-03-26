using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using VitrineApi.Classes.Dtos.CV;
using VitrineApi.Classes.CV;

namespace VitrineApi.Controllers;

[Route("cv")]
[ApiController]
public class CvController : ControllerBase
{
    private readonly IMapper _mapper;

    public CvController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpGet("experiences")]
    public async Task<IAsyncEnumerable<ExperienceDto>> Get()
    {


        return _mapper.Map<IAsyncEnumerable<ExperienceDto>>(experiences);
    }



}
