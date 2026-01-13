using System.Net;
using Domain.Dto.Participant;
using Domain.Dto.Team;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class TeamService(ApplicationDataContext context) : ITeamService
{
    #region CreateTeam
    public Response<string> CreateTeam(CreateTeamDto dto)
    {
        var newTeam = new Team()
        {
            Name = dto.Name,
            HackathonId = dto.HackathonId
        };
        context.Teams.Add(newTeam);
        var res = context.SaveChanges();
        return res > 0
            ? new Response<string>(HttpStatusCode.Created, " Team created Successfully !")
            : new Response<string>(HttpStatusCode.BadRequest, " Team created Failed !");
        
    }
    #endregion

    #region UpdateTeam
    public Response<string> UpdateTeam(int id, UpdateTeamDto dto)
    {
        var res = context.Teams.FirstOrDefault(x => x.Id == id);
        if(res == null)
            return new Response<string>(HttpStatusCode.NotFound,$"Team with id {id} not found");
        res.Name = dto.Name;
        var re = context.SaveChanges();
        return re > 0
            ? new Response<string>(HttpStatusCode.OK, " Team updated successfully !")
            : new Response<string>(HttpStatusCode.BadRequest, " Team updated failed !");
    }
    #endregion

    #region DeleteTeam
    public Response<string> DeleteTeam(int id)
    {
        var res = context.Teams.FirstOrDefault(x => x.Id == id);
        if(res ==  null)
            return new Response<string>(HttpStatusCode.NotFound, $"Team with id {id} not found");
        context.Teams.Remove(res);
        var rews2 = context.SaveChanges();
            return rews2 > 0
         ? new Response<string>(HttpStatusCode.OK, " Team deleted successfully !")
            : new Response<string>(HttpStatusCode.BadRequest, " Team deleted failed !");
    }
    #endregion

        #region GetAllTeams
    public Response<List<GetTeamDto>> GetAllTeam()
    {
        var res = context.Teams.Include(x => x.Hackathon).ToList();
        var dto = res.Select(z => new GetTeamDto()
        {
            Id = z.Id,
            Name = z.Name,
            HackathonId = z.HackathonId,
            CreatedDate = z.CreatedDate
        }).ToList();
        return new Response<List<GetTeamDto>>(dto);
    }
    #endregion

    #region  GetTeamById
    public Response<GetTeamDto> GetTeamById(int id)
    {
       var res = context.Teams.FirstOrDefault(x => x.Id == id);
       var dto = new GetTeamDto()
       {
           Id = res.Id,
           Name = res.Name,
           CreatedDate = res.CreatedDate
       };
       return new Response<GetTeamDto>(dto);

    }
    #endregion

    #region GetTeamWithParticipants
    public Response<List<GetTeamWithParticipant>> GetAllTeamsWithParticipant()
    {
        var res2 = context.Teams.Include(x => x.Participants).Select(s => new GetTeamWithParticipant()
        {
            Id = s.Id,
            Name = s.Name,
            Participants = s.Participants!.Select(z => new GetParticipantDto()
            {
                Id = z.Id,
                Name = z.Name,
                Email = z.Email,
                Role = z.Role
            }).ToList()
        }).ToList();
        return new Response<List<GetTeamWithParticipant>>(res2);
    }
    #endregion
    
    
}


 
