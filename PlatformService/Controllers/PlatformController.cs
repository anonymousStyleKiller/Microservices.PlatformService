using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.DTOs;
using PlatformService.Interfaces;

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

    [HttpGet]
    public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
    {
        return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(_repository.GetAllPlatforms()));
    }

    [HttpGet("{id:int}")]
    public ActionResult<PlatformReadDto> GetPlatformById(int id)
    {
        var platform = _repository.GetPlatformById(id);
        if(platform is  not  null) return Ok(_mapper.Map<PlatformReadDto>(platform));
        return NotFound();
    }
}