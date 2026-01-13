using Domain.Dto.Team;
using Domain.Responses;

namespace Infrastructure.Interfaces;

public interface ITeamService
{
    Response<string> CreateTeam(CreateTeamDto dto);
    Response<string> UpdateTeam(int id, UpdateTeamDto dto);
    Response<string> DeleteTeam(int id);
    Response<List<GetTeamDto>> GetAllTeam();
    Response<GetTeamDto> GetTeamById(int id);
    Response<List<GetTeamWithParticipant>> GetAllTeamsWithParticipant();

}