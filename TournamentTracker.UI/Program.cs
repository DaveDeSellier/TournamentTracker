using Microsoft.EntityFrameworkCore;
using TournamentTracker.Core;
using TournamentTracker.Core.Interfaces;
using TournamentTracker.Infrastructure;
using TournamentTracker.Infrastructure.Services;
using TournamentTracker.UI.ViewModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<TournamentTrackerContext>().AddDbContext<TournamentTrackerContext>(options =>
options.UseSqlServer("Data Source = DESKTOP - 6QE2B0K; Initial Catalog = TournamentTracker; Integrated Security = True; TrustServerCertificate = True;"), ServiceLifetime.Scoped);

//builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IPrize, PrizeService>();
builder.Services.AddScoped<IPerson, PersonService>();
builder.Services.AddScoped<ITeam, TeamService>();
builder.Services.AddScoped<ITeamMember, TeamMemberService>();
builder.Services.AddScoped<IMatchup, MatchupService>();
builder.Services.AddScoped<ITournament, TournamentService>();
builder.Services.AddScoped<IMatchupEntry, MatchupEntryService>();
builder.Services.AddScoped<TournamentLogic>();
builder.Services.AddScoped<TournamentVM>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
