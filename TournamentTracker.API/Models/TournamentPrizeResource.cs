namespace TournamentTracker.API.Models
{
    public class TournamentPrizeResource
    {

        public int Id { get; set; }

        public PrizeResource Prize { get; set; } = default!;
    }
}
