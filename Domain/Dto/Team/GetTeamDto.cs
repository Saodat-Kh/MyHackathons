namespace Domain.Dto.Team;

public class GetTeamDto
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public int HackathonId { get; set; }
    public DateTime CreatedDate { get; set; }= DateTime.UtcNow;
}