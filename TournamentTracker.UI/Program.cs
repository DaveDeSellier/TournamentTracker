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
builder.Services.AddDbContext<TournamentTrackerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConn")));
//builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<IPrize, PrizeService>();
builder.Services.AddTransient<IPerson, PersonService>();
builder.Services.AddTransient<ITeam, TeamService>();
builder.Services.AddTransient<ITeamMember, TeamMemberService>();
builder.Services.AddTransient<IMatchup, MatchupService>();
builder.Services.AddTransient<ITournament, TournamentService>();
builder.Services.AddTransient<IMatchupEntry, MatchupEntryService>();
builder.Services.AddTransient<TournamentLogic>();
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
