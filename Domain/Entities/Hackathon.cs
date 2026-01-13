namespace Domain.Entities;

public class Hackathon
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public DateTime  Data{ get; set; }= DateTime.UtcNow;
    public string Theme { get; set; } = String.Empty;
    
    //navigation
    public List<Team>? Teams { get; set; } 
    
}