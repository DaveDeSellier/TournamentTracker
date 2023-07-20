using TournamentTracker.Core.Models;

namespace TournamentTracker.UI.ViewModels
{
    public class TournamentEntryVM
    {
        public int Id { get; }

        public int TournamentId { get; set; }

        public int TeamId { get; set; }

        public TournamentEntry TournamentEntry { get; }

        public TournamentEntryVM()
        {
        }

        public TournamentEntryVM(TournamentEntry entry)
        {
            TournamentEntry = new()
            {


            };
        }


    }
}
