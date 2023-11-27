namespace TournamentTracker.API.Models
{
    public class PartialTournamentResource
    {
        public int Id { get; set; }
        public string TournamentName { get; set; } = null!;
        public decimal EntryFee { get; set; }

    }
}
