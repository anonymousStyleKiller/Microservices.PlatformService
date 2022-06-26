using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.DTOs;
using PlatformService.Interfaces;
using PlatformService.Models;

namespace PlatformService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlatformController : ControllerBase
{
    private readonly IPlatformRepository _repository;
    private readonly IMapper _mapper;

    public PlatformController(IPlatformRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get All Platforms
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
    {
        return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(_repository.GetAllPlatforms()));
    }

    /// <summary>
    /// Get a concrete platform 
    /// </summary>
    /// <param name="id">Id of platform</param>
    [HttpGet("{id:int}", Name = "GetPlatformById")]
    public ActionResult<PlatformReadDto> GetPlatformById(int id)
    {
        var platform = _repository.GetPlatformById(id);
        if(platform is  not  null) return Ok(_mapper.Map<PlatformReadDto>(platform));
        return NotFound();
    }

    /// <summary>
    /// Create a new platform
    /// </summary>
    /// <param name="platformCreateDto">Models of creating platform</param>
    [HttpPost]
    public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platformCreateDto)
    {
      var platformModel =  _mapper.Map<Platform>(platformCreateDto);
      _repository.CreatePlatform(platformModel);
      _repository.SaveChanges();

      var platformReadDto = _mapper.Map<PlatformReadDto>(platformModel);
      return CreatedAtRoute(nameof(GetPlatformById), new {platformReadDto.Id}, platformReadDto);
    } 
}