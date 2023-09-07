using TournamentTracker.Core.Models;

namespace TournamentTracker.Core
{
    public class TournamentLogic
    {

        //Create matchups
        //Order of list of teams randomly 
        //Check if the list of entries is a multiple of 2, if not, add byes
        //Create first round of match ups
        //Create every round after that - (16 teams) 8 matchup -  (8 teams) 4 matchups - (4 teams) 2 matchups - (2teams) 1 matchup


        public List<List<Matchup>> CreateRounds(Tournament vm)
        {
            List<List<Matchup>> rounds = new();

            List<Team> teams = new();

            foreach (var entry in vm.TournamentEntries)
            {

                teams.Add(entry.Team);

            }

            var randomizedTeams = RandomizeTeamOrder(teams);
            int roundNumber = FindNumberOfRounds(randomizedTeams.Count);
            int byes = NumberOfByes(roundNumber, randomizedTeams.Count);
            rounds.Add(CreateFirstRound(byes, randomizedTeams));
            CreateOtherRounds(roundNumber, rounds);

            return rounds;
        }

        private void CreateOtherRounds(int rounds, List<List<Matchup>> roundList)
        {
            int round = 2;
            List<Matchup> result = new();
            List<Matchup> previousRound = roundList[0];
            List<Matchup> currRound = new();
            Matchup currMatchup = new();

            while (round <= rounds)
            {

                foreach (Matchup match in previousRound)
                {
                    currMatchup.MatchupEntries.Add(new MatchupEntry { Matchup = match });

                    if (currMatchup.MatchupEntries.Count > 1)
                    {
                        currMatchup.MatchupRound = round;
                        currRound.Add(currMatchup);
                        currMatchup = new();

                    }
                }

                roundList.Add(currRound);
                previousRound = currRound;
                currRound = new();
                round++;


            }

        }

        private List<Matchup> CreateFirstRound(int byes, List<Team> teams)
        {
            List<Matchup> output = new List<Matchup>();
            Matchup curr = new();

            foreach (var team in teams)
            {
                curr.MatchupEntries.Add(new MatchupEntry { TeamCompeting = team });

                if (byes > 0 || curr.MatchupEntries.Count > 1)
                {

                    curr.MatchupRound = 1; //Create first round
                    output.Add(curr);
                    curr = new();

                    if (byes > 0)
                    {

                        byes--;
                    }
                }
            }

            return output;

        }

        private int NumberOfByes(int rounds, int numberOfTeams)
        {

            int output = 0;
            int totalTeams = 1;

            for (int i = 0; i < rounds; i++)
            {
                totalTeams *= 2;
            }

            output = totalTeams - numberOfTeams;

            return output;


        }

        private int FindNumberOfRounds(int teamCount)
        {
            int output = 1;
            int val = 2;
            while (val < teamCount)
            {
                output++;
                val *= 2;
            }

            return output;
        }

        private List<Team> RandomizeTeamOrder(List<Team> teams)
        {

            return teams.OrderBy(t => Guid.NewGuid()).ToList();

        }

        public static Tournament CreateTournament(Tournament vm)
        {

            Tournament tournament = new Tournament()
            {

                TournamentName = vm.TournamentName,
                TournamentEntries = vm.TournamentEntries,
                TournamentPrizes = vm.TournamentPrizes,
                Matchups = vm.Matchups

            };

            return tournament;

        }

    }
}
