using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace TournamentTracker.API.Models
{
    public class PrizeResource
    {

        public int Id { get; set; }

        [Required]
        public int PlaceNumber { get; set; } = default!;

        [Required]
        public string PlaceName { get; set; } = default!;

        [Required]
        public decimal PrizeAmount { get; set; } = default!;

        [Required]
        public double PrizePercentage { get; set; } = default!;


    }
}
