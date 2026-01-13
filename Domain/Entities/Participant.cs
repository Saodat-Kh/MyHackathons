namespace Domain.Entities;

public class Participant
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string? Role { get; set; } = String.Empty;
    public DateTime JoinedDate { get; set; } = DateTime.UtcNow;
    
    
    //navigation
    public int? TeamId { get; set; }
    public Team? Team { get; set; }

    
}