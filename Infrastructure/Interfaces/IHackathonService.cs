using Domain.Dto.Hackathon;
using Domain.Responses;

namespace Infrastructure.Interfaces;

public interface IHackathonService
{
    Response<string> CreateHackathon(CreateHackathonDto dto);
    Response<string> UpdateHacathon(int id, UpdateHackathonDto dto);
    Response<List<GetHackathonDto>>  GetAllHackathons();
    Response<GetHackathonDto>  GetHackathonById(int id);
    Response<List<GetHackathonWithTeam>>   GetAllHackathonWithTeams();
}