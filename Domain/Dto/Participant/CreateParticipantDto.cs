namespace Domain.Dto.Participant;

public class CreateParticipantDto
{
    public string Name { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string Role { get; set; } = String.Empty;
}