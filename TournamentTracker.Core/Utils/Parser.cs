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

            double number;

            var success = double.TryParse(s, out number);

            if (success)
            {
                return number;
            }
            else
            {

                throw new InvalidDataException("Enter a valid amount");
            }


        }

        public static decimal ParseDecimal(string s)
        {
            decimal number;

            bool success = decimal.TryParse(s, out number);

            if (success)
            {
                return number;
            }
            else
            {
                throw new InvalidDataException("Enter a valid amount");
            }
        }


    }
}
