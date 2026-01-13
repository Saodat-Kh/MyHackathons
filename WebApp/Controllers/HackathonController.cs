using System.Net;
using Domain.Dto.Hackathon;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class HackathonController(IHackathonService service) : ControllerBase
{
    [HttpPost]
    public IActionResult CreateHackathon(CreateHackathonDto dto)
    {
        var res = service.CreateHackathon(dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpPut]
    public IActionResult UpdateHackathon(int id,UpdateHackathonDto dto)
    {
        var res = service.UpdateHacathon(id, dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet]
    public IActionResult GetAllHackathons()
    {
        var res = service.GetAllHackathons();
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("id")]
    public IActionResult GetHacathonById(int id)
    {
        var res = service.GetHackathonById(id);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("HacathonWithTeam")]
    public IActionResult GetHacathonWithTeam()
    {
        var res = service.GetAllHackathonWithTeams();
        return StatusCode(res.StatusCode, res);
    }
    
    
    
}