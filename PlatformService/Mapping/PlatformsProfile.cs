using AutoMapper;
using PlatformService.DTOs;
using PlatformService.Models;

namespace PlatformService.Mapping;

public class PlatformsProfile : Profile
{
    public PlatformsProfile()
    {
        CreateMap<Platform, PlatformReadDto>();
        CreateMap<PlatformCreateDto, Platform>();
    }
}