namespace Domain.Dto.Team;

public class UpdateTeamDto
{
    public string? Name { get; set; } = String.Empty;
    public int? HackathonId { get; set; }
}