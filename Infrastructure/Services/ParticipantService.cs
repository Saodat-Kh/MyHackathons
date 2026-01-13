using System.Net;
using Domain.Dto.Participant;
using Domain.Dto.Team;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class ParticipantService(ApplicationDataContext context) : IParticipantService
{
    #region CreateParticipant
    public Response<string> CreateParticipant(CreateParticipantDto dto)
    {
        var newParticipant = new Participant()
        {
            Name = dto.Name,
            Email = dto.Email,
            Role = dto.Role,
            
        };
        context.Participants.Add(newParticipant);
        var res = context.SaveChanges();
        return res > 0
            ? new Response<string>(HttpStatusCode.Created, "Participant created successfully")
            : new Response<string>(HttpStatusCode.BadRequest, "Participant created failed");
    }
    #endregion

    public Response<string> UpdateParticipant(int id, UpdateParticipantDto dto)
    {
        var res = context.Participants.FirstOrDefault(x =>  x.Id == id);
        if(res == null)
            return new Response<string>(HttpStatusCode.NotFound, "Participant not found");
        res.Name = dto.Name;
        res.Email = dto.Email;
        res.Role = dto.Role;
        var res2 = context.SaveChanges();
        return res2 > 0
            ? new Response<string>(HttpStatusCode.OK, "Participant updated successfully")
            : new Response<string>(HttpStatusCode.BadRequest, "Participant updated failed");

    }

    public Response<string> DeleteParticipant(int id)
    {
        var res = context.Participants.FirstOrDefault(x => x.Id == id);
        if (res == null)
            return new Response<string>(HttpStatusCode.NotFound, "Participant not found");
        context.Participants.Remove(res);
        var res2 = context.SaveChanges();
        return res2 > 0
            ? new Response<string>(HttpStatusCode.OK, "Participant deleted successfully")
            : new Response<string>(HttpStatusCode.BadRequest, "Participant deleted failed");
    }

    public Response<List<GetParticipantDto>> GetAllParticipants()
    {
        var res = context.Participants.ToList();
        var dto = res.Select(z => new GetParticipantDto()
        {
            Id = z.Id,
            Name = z.Name,
            Email = z.Email,
            Role = z.Role,
            JoinedDate = z.JoinedDate
        }).ToList();
        return new Response<List<GetParticipantDto>>(dto);
    }

    public Response<GetParticipantDto> GetParticipantById(int id)
    {
        var res = context.Participants.FirstOrDefault(x => x.Id == id);
        if (res == null)
            return new Response<GetParticipantDto>(HttpStatusCode.NotFound, " Participnts not found");
        var dto = new GetParticipantDto()
        {
            Id = res.Id,
            Name = res.Name,
            Email = res.Email,
            Role = res.Role,
            JoinedDate = res.JoinedDate
        };
        return new Response<GetParticipantDto>(dto);
    }
}