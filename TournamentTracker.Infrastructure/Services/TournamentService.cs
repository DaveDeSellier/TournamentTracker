using Microsoft.Extensions.Logging;
using TournamentTracker.Core;
using TournamentTracker.Core.Interfaces;
using TournamentTracker.Core.Models;

namespace TournamentTracker.Infrastructure.Services
{
    public class TournamentService : Repository<Tournament>, ITournament
    {
        private readonly TournamentTrackerContext _context;
        private readonly TournamentLogic _tournamentLogic;

        public TournamentService(TournamentTrackerContext context, TournamentLogic tournamentLogic, ILogger<TournamentService> logger) : base(context, logger)
        {
            _context = context;
            _tournamentLogic = tournamentLogic;
        }

        public async Task InsertTournament(Tournament tournament)
        {

            var transaction = _context.Database.BeginTransaction();

            try
            {

                var tournamentRecord = (new Tournament { TournamentName = tournament.TournamentName, EntryFee = tournament.EntryFee });

                await Add(tournamentRecord);

                var lastTournament = _context.Tournaments.Find(tournamentRecord.Id);

                foreach (var team in tournament.TournamentEntries)
                {

                    var teamRecord = _context.Teams.Find(team.Team.Id);

                    if (teamRecord != null)
                    {

                        lastTournament.TournamentEntries.Add(new TournamentEntry() { Team = teamRecord });


                    }
                    else
                    {


                        lastTournament.TournamentEntries.Add(team);

                    }

                }


                foreach (var prize in tournament.TournamentPrizes)
                {


                    var prizeRecord = _context.Prizes.Find(prize.Prize.Id);

                    if (prizeRecord != null)
                    {
                        lastTournament.TournamentPrizes.Add(new TournamentPrize() { Prize = prizeRecord });
                    }
                    else
                    {
                        lastTournament.TournamentPrizes.Add(prize);
                    }

                }


                // Create Rounds
                List<List<Matchup>> rounds = _tournamentLogic.CreateRounds(lastTournament);

                //Add Rounds
                foreach (List<Matchup> round in rounds)
                {

                    foreach (Matchup matchup in round)
                    {

                        matchup.Tournament = lastTournament;

                        foreach (var entry in matchup.MatchupEntries)
                        {

                            if (entry.Matchup != null)
                            {

                                entry.ParentMatchupId = entry.Matchup.Id;
                            }

                        }

                        _context.Matchups.Add(matchup);
                        await _context.SaveChangesAsync();

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
