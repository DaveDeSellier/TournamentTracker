using TournamentTracker.Core.Models;
using TournamentTracker.Infrastructure.Data;

namespace TournamentTracker.Infrastructure.Specifications
{
    public class TeamSpecification : BaseSpecification<Team>
    {

        public TeamSpecification(int teamId) : base(x => x.Id == teamId)
        {
            AddInclude(x => x.TeamMembers);
        }
    }
}
