using System.Net;
using System.Net.Mime;
using Domain.Dto.Hackathon;
using Domain.Dto.Team;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class HackathonService(ApplicationDataContext context) : IHackathonService
{
    public Response<string> CreateHackathon(CreateHackathonDto dto)
    {
        var newHackathon = new Hackathon()
        {
            Name = dto.Name,
            Theme = dto.Theme,
        };
     context.Hackathons.Add(newHackathon);
     var res = context.SaveChanges();
     return res > 0
         ? new Response<string>(HttpStatusCode.Created,$"Hackathon created successfully")
         : new Response<string>(HttpStatusCode.BadRequest,$"Hackathon could not be created");
    }

    public Response<string> UpdateHacathon(int id, UpdateHackathonDto dto)
    {
        var res = context.Hackathons.FirstOrDefault(x => x.Id == id);
        if (res == null)
            return new Response<string>(HttpStatusCode.NotFound,$"Hackathon could not be found");
        res.Name = dto.Name;
        res.Theme = dto.Theme;
        var effect =  context.SaveChanges();
        return effect > 0
            ? new Response<string>(HttpStatusCode.OK, $"Hackathon updated successfully")
            : new Response<string>(HttpStatusCode.BadRequest,$"Hackathon could not be updated");
    }

    public Response<List<GetHackathonDto>> GetAllHackathons()
    {
        var res = context.Hackathons
            .Include(x => x.Teams).ToList();
        var dto = res.Select(x => new GetHackathonDto()
        {
            Id = x.Id,
            Name = x.Name,
            Theme = x.Theme,
            Data = x.Data
        }).ToList();
        return new Response<List<GetHackathonDto>>(dto);





    }

    public Response<GetHackathonDto> GetHackathonById(int id)
    {
        var res = context.Hackathons.FirstOrDefault(x => x.Id == id);
        var dto = new GetHackathonDto()
        {
            Id = res.Id,
            Name = res.Name,
            Theme = res.Theme,
            Data = res.Data
        };
        return new Response<GetHackathonDto>(dto);
    }

    public Response<List<GetHackathonWithTeam>>   GetAllHackathonWithTeams()
    {
        var res = context.Hackathons.Include(x => x.Teams).Select(x => new GetHackathonWithTeam()
        {
            Id = x.Id,
            Name = x.Name,
            Theme = x.Theme,
            Teams = x.Teams!.Select(z => new GetTeamDto()
            {
                Id = z.Id,
                Name = z.Name,

            }).ToList()
        }).ToList();
        return new Response<List<GetHackathonWithTeam>>(res);
    }
}