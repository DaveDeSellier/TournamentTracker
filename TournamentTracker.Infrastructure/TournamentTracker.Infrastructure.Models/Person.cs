using System;
using System.Collections.Generic;

namespace TournamentTracker.Infrastructure.TournamentTracker.Infrastructure.Models;

public partial class Person
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public virtual ICollection<TeamMember> TeamMembers { get; set; } = new List<TeamMember>();
}
