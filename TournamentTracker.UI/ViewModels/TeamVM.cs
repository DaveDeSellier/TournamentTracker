using System.ComponentModel.DataAnnotations;
using TournamentTracker.Core.Models;

namespace TournamentTracker.UI.ViewModels
{
    public class TeamVM
    {
        public int Id { get; private set; }

        [Required]
        public string TeamName { get; set; } = null!;

        public ICollection<TeamMember> TeamMembers { get; set; }

        public Team Team { get; } = new();

        public TeamVM()
        {

        }

        public TeamVM(Team team)
        {
            Id = team.Id;
            TeamName = team.TeamName;
            TeamMembers = team.TeamMembers;
        }

        public TeamVM(string teamName, List<PersonVM> list)
        {
            Team = new()
            {
                Id = Team.Id,
                TeamName = teamName,
                TeamMembers = ConvertToTeamMemberList(list)
            };

        }

        private List<TeamMember> ConvertToTeamMemberList(List<PersonVM> list)
        {

            List<TeamMember> result = new List<TeamMember>();

            foreach (PersonVM person in list)
            {

                var member = new TeamMember()
                {

                    PersonId = person.Id,

                };

                result.Add(member);

            }

            return result;
        }

    }
}
