using Domain.Dto.Participant;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ParticipantController(IParticipantService service) : ControllerBase
{
    [HttpPost]
    public IActionResult CreateParticipant(CreateParticipantDto dto)
    {
        var res = service.CreateParticipant(dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpPut]
    public IActionResult UpdateParticipant(int id,UpdateParticipantDto dto)
    {
        var res = service.UpdateParticipant(id, dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpDelete]
    public IActionResult DeleteParticipant(int id)
    {
        var res = service.DeleteParticipant(id);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet]
    public IActionResult GetAllParticipants()
    {
        var res = service.GetAllParticipants();
        return StatusCode(res.StatusCode, res);
    }


    [HttpGet("id")]
    public IActionResult GetParticipantById(int id)
    {
        var res = service.GetParticipantById(id);
        return StatusCode(res.StatusCode, res);
    }
    
    

}