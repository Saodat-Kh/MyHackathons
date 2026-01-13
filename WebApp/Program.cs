using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDataContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString")) );
builder.Services.AddScoped<ApplicationDataContext>();
builder.Services.AddScoped<IHackathonService, HackathonService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IParticipantService, ParticipantService>();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();