namespace Domain.Dto.Hackathon;

public class UpdateHackathonDto
{
    public string? Theme { get; set; }  = String.Empty; 
    public string? Name { get; set; } =  String.Empty;
    public int TeamId { get; set; }
}