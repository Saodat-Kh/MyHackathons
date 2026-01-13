namespace Domain.Entities;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
     
    public DateTime CreatedDate { get; set; }= DateTime.UtcNow;
    
    //navigation
    public int HackathonId { get; set; }
    public Hackathon? Hackathon { get; set; }
    public List<Participant>? Participants { get; set; }
}