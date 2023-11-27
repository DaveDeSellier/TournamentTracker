using TournamentTracker.Core.Models.Abstract;

namespace TournamentTracker.Core.Models
{
    public class Person : BaseModel
    {

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string EmailAddress { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public DateTime CreateDate { get; set; }

        public virtual ICollection<TeamMember> TeamMembers { get; set; } = new List<TeamMember>();

    }
}
