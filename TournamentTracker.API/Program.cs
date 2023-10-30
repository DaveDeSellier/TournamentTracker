using Microsoft.EntityFrameworkCore;
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

builder.Services.AddControllers()
    .AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TournamentTrackerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConn")));
builder.Services.AddTransient<ITournament, TournamentService>();
builder.Services.AddTransient<IPrize, PrizeService>();
builder.Services.AddTransient<TournamentLogic>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
