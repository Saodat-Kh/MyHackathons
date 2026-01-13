namespace Domain.Entities;

public class BaseEntities
{
    public int Id { get; set; }
    public DateTime Data { get; set; }= DateTime.UtcNow;
}