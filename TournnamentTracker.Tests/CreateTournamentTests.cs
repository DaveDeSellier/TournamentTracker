using Microsoft.AspNetCore.Components;
using System;
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
        public void Test_AddToTeamListButton_WhenATeamIsSelected()
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

            cut.WaitForState(() => selectATeamList.ChildElementCount > 1, TimeSpan.FromSeconds(1));

            var btnAddToTeamList = cut.Find("#btnAddTeamToList");

            var selectedTeamList = cut.Find("#SelectedTeamList");

            var changeArgs = new ChangeEventArgs();

            var lastChild = selectATeamList.LastChild.TextContent;

            changeArgs.Value = lastChild;

            //Act
            cut.InvokeAsync(async () => await selectATeamList.ChangeAsync(changeArgs));

            btnAddToTeamList.Click();

            //Assert
            cut.WaitForState(() => selectedTeamList.ChildElementCount > 0, TimeSpan.FromSeconds(1));

        }


    }
}


