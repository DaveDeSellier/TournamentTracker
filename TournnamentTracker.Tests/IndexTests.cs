using Microsoft.AspNetCore.Components;
using TournamentTracker.UI.Components;
using TournamentTracker.UI.Pages;

namespace TournnamentTracker.Tests
{
    public class IndexTests : TestContext
    {
        [Fact]
        public void Test_Index_InitializationState()
        {

            // Arrange
            //Services.AddSingleton<ITournament>(new TournamentService(new TournamentTrackerContext(), new TournamentLogic()));
            var navMan = Services.GetRequiredService<FakeNavigationManager>();
            var cut = RenderComponent<Index>();

            cut.WaitForState(() => cut.Find("select").ChildElementCount >= 1, System.TimeSpan.FromSeconds(1));

            var tournamentDropDownList = cut.Find("select");

            Assert.True(tournamentDropDownList.ChildElementCount >= 1);
            Assert.Equal("http://localhost/", navMan.Uri);
        }

        [Fact]
        public void Test_LoadTournamentButton_WhenNoTournamentIsSelected()
        {
            // Arrange
            // Services.AddSingleton<ITournament>(new TournamentService(new TournamentTrackerContext(), new TournamentLogic()));
            var navMan = Services.GetRequiredService<FakeNavigationManager>();
            var cut = RenderComponent<Index>();

            var btnLoadTournament = cut.Find("div > button:first-child");

            btnLoadTournament.Click();

            Assert.True(cut.Instance.isVisible == true);
            Assert.False(string.IsNullOrEmpty(cut.Instance.ErrorMessage));
            Assert.True(cut.HasComponent<Alert>());
            Assert.Equal("http://localhost/", navMan.Uri);

        }

        [Fact]
        public void Test_LoadTournamentButton_WhenTournamentIsSelected()
        {
            // Arrange
            //Services.AddSingleton<ITournament>(new TournamentService(new TournamentTrackerContext(), new TournamentLogic()));
            var navMan = Services.GetRequiredService<FakeNavigationManager>();
            var cut = RenderComponent<Index>();

            var tournamentDropDownList = cut.Find("select");

            var changeArgs = new ChangeEventArgs();

            changeArgs.Value = 1;

            cut.InvokeAsync(async () => await tournamentDropDownList.ChangeAsync(changeArgs));

            var btnLoadTournament = cut.Find("div > button:first-child");

            //Act
            btnLoadTournament.Click();

            //Assert
            Assert.True(cut.Instance.isVisible == false);
            Assert.True(string.IsNullOrEmpty(cut.Instance.ErrorMessage));
            Assert.False(cut.HasComponent<Alert>());
            Assert.Equal("http://localhost/tournament/1", navMan.Uri);

        }

        [Fact]
        public void Test_CreateTournamentBtn_NavigationToCreateTournamentPage()
        {
            //Arrange
            // Services.AddSingleton<ITournament>(new TournamentService(new TournamentTrackerContext(), new TournamentLogic()));
            var navMan = Services.GetRequiredService<FakeNavigationManager>();
            var cut = RenderComponent<Index>();

            var btnCreateTournament = cut.Find("div > button:last-child");

            //Act
            btnCreateTournament.Click();
            cut.WaitForState(() => navMan.Uri == "http://localhost/createtournament", System.TimeSpan.FromSeconds(1));

            var createTournmamentComponent = cut.FindComponents<CreateTournament>();

            //Assert
            Assert.Equal("http://localhost/createtournament", navMan.Uri);
        }

    }
}

