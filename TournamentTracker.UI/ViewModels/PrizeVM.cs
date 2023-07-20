using System.ComponentModel.DataAnnotations;
using TournamentTracker.Core.Models;
using TournamentTracker.Core.Utils;

namespace TournamentTracker.UI.ViewModels
{
    public class PrizeVM
    {
        public int Id { get; }

        [Required]
        public string PlaceNumber { get; set; }

        [Required]
        public string PlaceName { get; set; } = null!;

        [Required]
        public string PrizeAmount { get; set; }

        [Required]
        public string PrizePercentage { get; set; }

        public Prize Prize { get; } = new();

        public PrizeVM()
        {

        }

        public PrizeVM(Prize prize)
        {
            Id = prize.Id;
            PlaceName = prize.PlaceName;
            PlaceNumber = prize.PlaceNumber.ToString();
            PrizeAmount = prize.PrizeAmount.ToString();
            PrizePercentage = prize.PrizePercentage.ToString();
        }


        public PrizeVM(string placeName, string placeNumber, string prizeAmount, string prizePercentage)
        {

            Prize = new()
            {

                PlaceName = placeName,
                PlaceNumber = Parser.ParseInt(placeNumber),
                PrizeAmount = Parser.ParseDecimal(prizeAmount),
                PrizePercentage = Parser.ParseDouble(prizePercentage)

            };

        }
    }
}
