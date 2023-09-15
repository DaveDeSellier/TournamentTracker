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

        public TeamVM()
        {

        }

        public TeamVM(Team team)
        {
            Id = team.Id;
            TeamName = team.TeamName;
            TeamMembers = team.TeamMembers;
        }

        public static Team CreateTeam(string teamName, List<PersonVM> personList)
        {

            return new Team()
            {
                TeamName = teamName,
                TeamMembers = ConvertToTeamMemberList(personList)
            };

        }

        private static List<TeamMember> ConvertToTeamMemberList(List<PersonVM> list)
        {

            List<TeamMember> result = new List<TeamMember>();

            foreach (PersonVM person in list)
            {

                var member = new TeamMember()
                {

                    Person = PersonVM.CreatePerson(person)

                };

                result.Add(member);

            }

            return result;
        }

        public static Team CreateTeam(TeamVM vm)
        {

            Team team = new Team()
            {
                Id = vm.Id,
                TeamName = vm.TeamName,
                TeamMembers = vm.TeamMembers

            };

            return team;
        }
    }
}
