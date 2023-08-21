using Microsoft.AspNetCore.Components;
using TournamentTracker.Core.Interfaces;
using TournamentTracker.Infrastructure;
using TournamentTracker.Infrastructure.Services;
using TournamentTracker.UI.Components;
using TournamentTracker.UI.Pages;

namespace TournnamentTracker.Tests
{
    public class IndexTests : TestContext
    {
        [Fact]
        public async void Test_Index_InitializationState()
        {

            // Arrange
            Services.AddSingleton<ITournament>(new TournamentService(new TournamentTrackerContext()));
            var cut = RenderComponent<Index>();

            //Add this to invoke OnInitializedAsync 
            cut.WaitForState(() => cut.Find("select").ChildElementCount > 1, System.TimeSpan.FromSeconds(1));

            var tournamentDropDownList = cut.Find("select");

            Assert.True(cut.Instance.isVisible == false);
            Assert.True(cut.Instance.ErrorMessage == string.Empty);
            Assert.True(tournamentDropDownList.ChildElementCount > 1);
        }

        [Fact]
        public void Test_LoadTournamentButton_WhenNoTournamentIsSelected()
        {
            // Arrange
            Services.AddSingleton<ITournament>(new TournamentService(new TournamentTrackerContext()));
            var cut = RenderComponent<Index>();

            var btnLoadTournament = cut.Find("div > button:first-child");

            btnLoadTournament.Click();

            Assert.True(cut.Instance.isVisible == true);
            Assert.False(string.IsNullOrEmpty(cut.Instance.ErrorMessage));
            Assert.True(cut.HasComponent<Alert>());

        }

        [Fact]
        public async void Test_LoadTournamentButton_WhenTournamentIsSelected()
        {
            // Arrange
            Services.AddSingleton<ITournament>(new TournamentService(new TournamentTrackerContext()));
            var cut = RenderComponent<Index>();

            var tournamentDropDownList = cut.Find("select");

            var changeArgs = new ChangeEventArgs();

            changeArgs.Value = 1;

            await cut.InvokeAsync(() => tournamentDropDownList.ChangeAsync(changeArgs));

            var btnLoadTournament = cut.Find("div > button:first-child");

            btnLoadTournament.Click();

            Assert.True(cut.Instance.isVisible == false);
            Assert.True(string.IsNullOrEmpty(cut.Instance.ErrorMessage));
            Assert.False(cut.HasComponent<Alert>());

        }
    }
}

