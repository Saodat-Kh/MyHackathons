using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : DbContext(options)
{
    public DbSet<Hackathon> Hackathons { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Participant> Participants { get; set; }
}