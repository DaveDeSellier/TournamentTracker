using AngleSharp;
using AngleSharp.Html.Parser;
using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using TournamentTracker.Core;
using TournamentTracker.Core.Interfaces;
using TournamentTracker.Infrastructure;
using TournamentTracker.Infrastructure.Services;
using TournamentTracker.UI.Pages;

namespace TournnamentTracker.Tests
{
    public class CreateTournamentTests : TestContext
    {
        [Fact]
        public void Test_InitializationState()
        {

            // Arrange
            Services.AddSingleton<ITournament>(new TournamentService(new TournamentTrackerContext()));
            Services.AddSingleton<ITeam>(new TeamService(new TournamentTrackerContext()));
            Services.AddSingleton<IMatchup>(new MatchupService(new TournamentTrackerContext()));
            Services.AddSingleton<IMatchupEntry>(new MatchupEntryService(new TournamentTrackerContext()));
            Services.AddSingleton<IPrize>(new PrizeService(new TournamentTrackerContext()));
            Services.AddSingleton<TournamentLogic>();

            var cut = RenderComponent<CreateTournament>();

            var teamList = cut.Find("#TeamList");
            var prizeList = cut.Find("#PrizeList");

            //Assert 
            Assert.NotNull(teamList);
            Assert.NotNull(prizeList);
            Assert.True(teamList.ChildElementCount >= 0);
            Assert.True(prizeList.ChildElementCount >= 0);
            Assert.True(cut.Instance.isVisible == false);
            Assert.True(string.IsNullOrEmpty(cut.Instance.ErrorMessage));

        }

        [Fact]
        public void Test_AddToTeamListButton_WhenNoTeamIsSelected()
        {
            // Arrange
            Services.AddSingleton<ITournament>(new TournamentService(new TournamentTrackerContext()));
            Services.AddSingleton<ITeam>(new TeamService(new TournamentTrackerContext()));
            Services.AddSingleton<IMatchup>(new MatchupService(new TournamentTrackerContext()));
            Services.AddSingleton<IMatchupEntry>(new MatchupEntryService(new TournamentTrackerContext()));
            Services.AddSingleton<IPrize>(new PrizeService(new TournamentTrackerContext()));
            Services.AddSingleton<TournamentLogic>();

            var cut = RenderComponent<CreateTournament>();

            var selectedTeamList = cut.Find("#SelectedTeamList");

            var btnAddToTeamList = cut.Find("#btnAddTeamToList");

            //Act
            btnAddToTeamList.Click();

            //Assert
            Assert.True(selectedTeamList.ChildElementCount == 0);

        }

        [Fact]
        public async void Test_AddToTeamListButton_WhenATeamIsSelected()
        {
            // Arrange
            Services.AddSingleton<ITournament>(new TournamentService(new TournamentTrackerContext()));
            Services.AddSingleton<ITeam>(new TeamService(new TournamentTrackerContext()));
            Services.AddSingleton<IMatchup>(new MatchupService(new TournamentTrackerContext()));
            Services.AddSingleton<IMatchupEntry>(new MatchupEntryService(new TournamentTrackerContext()));
            Services.AddSingleton<IPrize>(new PrizeService(new TournamentTrackerContext()));
            Services.AddSingleton<TournamentLogic>();

            var cut = RenderComponent<CreateTournament>();

            var selectATeamList = cut.Find("#TeamList");

            var context = BrowsingContext.New(Configuration.Default);
            var document = await context.OpenAsync(r => r.Content(selectATeamList.TextContent));
            var app = document.QuerySelector("li");
            var parser = context.GetService<IHtmlParser>();
            var nodes = parser.ParseFragment("<div id='div1'>hi<p>world</p></div>", app);
            app.Append(nodes.ToArray());

            cut.WaitForState(() => selectATeamList.ChildElementCount > 1, TimeSpan.FromSeconds(1));

            var btnAddToTeamList = cut.Find("#btnAddTeamToList");
            var selectedTeamList = cut.Find("#SelectedTeamList");
            var changeArgs = new ChangeEventArgs();
            var lastChild = selectATeamList.LastChild.TextContent;

            changeArgs.Value = lastChild;

            //Act
            cut.InvokeAsync(async () => await selectATeamList.ChangeAsync(changeArgs));

            btnAddToTeamList.Click();

            cut.WaitForState(() => selectedTeamList.ChildElementCount > 0, TimeSpan.FromSeconds(1));

            //Assert
            Assert.True(selectedTeamList.ChildElementCount == 1);


        }


    }
}


