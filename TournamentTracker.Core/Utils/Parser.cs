namespace TournamentTracker.Core.Utils
{
    public static class Parser
    {

        public static int ParseInt(string s)
        {
            int number;

            var success = int.TryParse(s, out number);

            if (success)
            {

                return number;
            }

            return 0;
        }

        public static double ParseDouble(string s)
        {

            return double.Parse(s);
        }

        public static decimal ParseDecimal(string s)
        {
            return decimal.Parse(s);
        }


    }
}
