using TournamentTracker.Core;
using TournamentTracker.Core.Interfaces;
using TournamentTracker.Core.Models;

namespace TournamentTracker.Infrastructure.Services
{
    public class TournamentService : Repository<Tournament>, ITournament
    {
        private readonly TournamentTrackerContext _context;
        private readonly TournamentLogic _tournamentLogic;
        public TournamentService(TournamentTrackerContext context, TournamentLogic tournamentLogic) : base(context)
        {
            _context = context;
            _tournamentLogic = tournamentLogic;
        }

        public async Task InsertTournament(Tournament tournament)
        {

            var transaction = _context.Database.BeginTransaction();

            Console.WriteLine(_context.ChangeTracker.DebugView.LongView);

            _context.ChangeTracker.Clear();

            try
            {

                var tournamentRecord = (new Tournament { TournamentName = tournament.TournamentName, EntryFee = tournament.EntryFee });

                await Add(tournamentRecord);

                var lastTournament = _context.Tournaments.Find(tournamentRecord.Id);

                lastTournament.TournamentEntries = tournament.TournamentEntries;

                lastTournament.TournamentPrizes = tournament.TournamentPrizes;

                // Create Rounds
                List<List<Matchup>> rounds = _tournamentLogic.CreateRounds(lastTournament);

                //Add Rounds
                foreach (List<Matchup> round in rounds)
                {

                    foreach (Matchup matchup in round)
                    {

                        foreach (var entry in matchup.MatchupEntries)
                        {

                            if (entry.Matchup != null)
                            {

                                entry.ParentMatchupId = entry.Matchup.Id;
                            }

                        }

                        lastTournament.Matchups.Add(matchup);

                    }

                }

                await _context.SaveChangesAsync();

                transaction.Commit();
            }
            catch (Exception)
            {

                transaction.Rollback();
                throw;

            }
        }

        public async Task<Tournament> SaveTournamentRound(Tournament tournament)
        {
            _context.Add(tournament);
            await _context.SaveChangesAsync();

            return tournament;
        }


    }
}
