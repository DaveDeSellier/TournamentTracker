using System;
using System.Collections.Generic;

namespace TournamentTracker.Infrastructure.TournamentTracker.Infrastructure.Models;

public partial class TeamMember
{
    public int Id { get; set; }

    public int TeamId { get; set; }

    public int PersonId { get; set; }

    public virtual Person Person { get; set; } = null!;

    public virtual Team Team { get; set; } = null!;
}
