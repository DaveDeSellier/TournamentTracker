using System.ComponentModel.DataAnnotations;
using TournamentTracker.Core.Models;
using TournamentTracker.Core.Utils;

namespace TournamentTracker.UI.ViewModels
{
    public class TournamentVM
    {
        public int Id { get; }

        [Required]
        public string TournamentName { get; set; }

        [Required]
        public string EntryFee { get; set; }

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
                EntryFee = Parser.ParseDecimal(vm.EntryFee),
                TournamentName = vm.TournamentName,
                TournamentEntries = vm.TournamentEntries,
                TournamentPrizes = vm.TournamentPrizes,
                Matchups = vm.Matchups

            };

            return tournament;

        }

    }


}


