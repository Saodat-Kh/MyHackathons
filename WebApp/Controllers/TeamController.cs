using Domain.Dto.Team;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TeamController(ITeamService service) : ControllerBase
{
    [HttpPost]
    public IActionResult CreateTeam(CreateTeamDto dto)
    {
        var res = service.CreateTeam(dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpPut]
    public IActionResult UpdateTeam(int id, UpdateTeamDto dto)
    {
        var res = service.UpdateTeam(id, dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpDelete]
    public IActionResult DeleteTeam(int id)
    {
        var res = service.DeleteTeam(id);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet]
    public IActionResult GetAllTeams()
    {
        var res = service.GetAllTeam();
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("id")]
    public IActionResult GetTeamById(int id)
    {
        var res = service.GetTeamById(id);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("TeamWithParticipant")]
    public IActionResult GetTeamWithParticipant()
    {
        var res = service.GetAllTeamsWithParticipant();
        return StatusCode(res.StatusCode, res);
    }


}