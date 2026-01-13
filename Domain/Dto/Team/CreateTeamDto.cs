namespace Domain.Dto.Team;

public class CreateTeamDto
{
    public string Name { get; set; } = String.Empty;
    public int HackathonId { get; set; }
}