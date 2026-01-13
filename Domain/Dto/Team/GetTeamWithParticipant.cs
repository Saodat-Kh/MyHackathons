using Domain.Dto.Participant;

namespace Domain.Dto.Team;

public class GetTeamWithParticipant
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;

    public List<GetParticipantDto> Participants { get; set; }
}