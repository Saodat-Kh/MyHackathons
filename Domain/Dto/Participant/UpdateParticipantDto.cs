namespace Domain.Dto.Participant;

public class UpdateParticipantDto
{
    public string? Name { get; set; } = String.Empty;
    public string? Email { get; set; } = String.Empty;
    public string? Role { get; set; } = String.Empty;
    
    public int? TeaamId { get; set; }
}