using System.ComponentModel.DataAnnotations;
using TournamentTracker.Core.Models;

namespace TournamentTracker.UI.ViewModels
{
    public class TournamentVM
    {
        public int Id { get; }

        [Required(ErrorMessage = "Please enter a tournament name")]
        public string TournamentName { get; set; }

        [Required(ErrorMessage = "Please enter an entry fee")]
        [Range(minimum: 1.00, maximum: 1000.00, ErrorMessage = "Please enter an entry fee between 1.00 and 1000.00")]
        [RegularExpression(@"^[0-9]*(\.[0-9]{1,2})?$", ErrorMessage = "Please enter an entry fee that contains up to two decimal places")]
        public decimal? EntryFee { get; set; }

        public virtual ICollection<Matchup> Matchups { get; set; } = new List<Matchup>();

        public virtual ICollection<TournamentEntry> TournamentEntries { get; set; } = new List<TournamentEntry>();

        public virtual ICollection<TournamentPrize> TournamentPrizes { get; set; } = new List<TournamentPrize>();

        public TournamentVM()
        {

        }

        public TournamentVM(Tournament tournament)
        {
            Id = tournament.Id;
            TournamentName = tournament.TournamentName;
        }

        public TournamentVM(Tournament tournament, int id)
        {
            Id = id;
            TournamentName = tournament.TournamentName;
            TournamentEntries = tournament.TournamentEntries;
            TournamentPrizes = tournament.TournamentPrizes;
            Matchups = tournament.Matchups;
        }

        public static Tournament CreateTournament(TournamentVM vm)
        {

            Tournament tournament = new Tournament()
            {
                EntryFee = vm.EntryFee ?? 0,
                TournamentName = vm.TournamentName,
                TournamentEntries = vm.TournamentEntries,
                TournamentPrizes = vm.TournamentPrizes,
                Matchups = vm.Matchups

            };

            return tournament;

        }

    }


}


