﻿using AutoMapper;
using VitrineApi.Classes.CV;
using VitrineApi.Classes.Dtos.CV;

namespace VitrineApi.Classes;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Experience, ExperienceDto>();
        CreateMap<ExperienceDto, Experience>();

        CreateMap<Formation, FormationDto>();
        CreateMap<FormationDto, Formation>();

        CreateMap<Certification, CertificationDto>();
        CreateMap<CertificationDto, Certification>();
    }
}
