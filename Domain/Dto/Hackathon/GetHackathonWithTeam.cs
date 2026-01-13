using Domain.Dto.Team;

namespace Domain.Dto.Hackathon;

public class GetHackathonWithTeam
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Theme { get; set; } = String.Empty;


    public List<GetTeamDto> Teams { get; set; } = new List<GetTeamDto>();
}