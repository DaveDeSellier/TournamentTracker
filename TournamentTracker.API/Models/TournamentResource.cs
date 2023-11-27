namespace TournamentTracker.API.Models
{
    public class TournamentResource
    {
        public int Id { get; set; }
        public string TournamentName { get; set; } = null!;
        public decimal EntryFee { get; set; }

        public virtual ICollection<MatchupResource> Matchups { get; set; } = new List<MatchupResource>();

        public virtual ICollection<TournamentEntryResource> TournamentEntries { get; set; } = new List<TournamentEntryResource>();

        public virtual ICollection<TournamentPrizeResource> TournamentPrizes { get; set; } = new List<TournamentPrizeResource>();
    }
}
