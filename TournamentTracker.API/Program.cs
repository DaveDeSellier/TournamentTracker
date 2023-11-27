using Microsoft.EntityFrameworkCore;
using TournamentTracker.API.Filter;
using TournamentTracker.API.Filters;
using TournamentTracker.API.Mapper;
using TournamentTracker.Core;
using TournamentTracker.Core.Interfaces;
using TournamentTracker.Infrastructure;
using TournamentTracker.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var CorsOrigins = builder.Configuration.GetValue<string>("Cors:Origin");

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
                      policy =>
                      {
                          policy.WithOrigins(CorsOrigins)
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ExceptionFilter>();
    options.Filters.Add<HttpFilter>();
    options.Filters.Add<LinkRewritingFilter>();

})
    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen().AddSwaggerGenNewtonsoftSupport();
builder.Services.AddDbContext<TournamentTrackerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConn")));
builder.Services.AddScoped<ITournament, TournamentService>();
builder.Services.AddScoped<IPrize, PrizeService>();
builder.Services.AddScoped<IMatchup, MatchupService>();
builder.Services.AddScoped<ITeamMember, TeamMemberService>();
builder.Services.AddScoped<ITeam, TeamService>();
builder.Services.AddScoped<TournamentLogic>();
builder.Services.AddAutoMapper(options => options.AddProfile<MappingProfile>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//Do not allow http request to redirect to https. Instead refuse HTTP connections.
//app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
