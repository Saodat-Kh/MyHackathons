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
    
}