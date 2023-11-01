namespace TournamentTracker.API.Models
{
    public class TournamentResource : Resource
    {
        public string TournamentName { get; set; } = null!;
        public decimal EntryFee { get; set; }
    }
}
