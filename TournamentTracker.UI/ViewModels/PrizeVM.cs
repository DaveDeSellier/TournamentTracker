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

        public static Prize CreatePrize(PrizeVM vm)
        {
            Prize prize = new Prize()
            {
                Id = vm.Id,
                PlaceName = vm.PlaceName,
                PlaceNumber = Parser.ParseInt(vm.PlaceNumber),
                PrizeAmount = Parser.ParseDecimal(vm.PrizeAmount)

            };

            return prize;
        }
    }
}
