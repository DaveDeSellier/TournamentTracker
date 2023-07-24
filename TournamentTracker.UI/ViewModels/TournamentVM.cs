﻿using System.ComponentModel.DataAnnotations;
using TournamentTracker.Core.Models;

namespace TournamentTracker.UI.ViewModels
{
    public class TournamentVM
    {
        public int Id { get; }

        [Required]
        public string TournamentName { get; set; } = null!;

        [Required]
        public string EntryFee { get; set; }

        public List<Team> EnteredTeams = new List<Team>();

        public virtual ICollection<Matchup> Matchups { get; set; } = new List<Matchup>();

        public virtual ICollection<TournamentEntry> TournamentEntries { get; set; } = new List<TournamentEntry>();

        public virtual ICollection<TournamentPrize> TournamentPrizes { get; set; } = new List<TournamentPrize>();

        public List<List<Matchup>> Rounds { get; set; } = new List<List<Matchup>>();

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

    }


}

