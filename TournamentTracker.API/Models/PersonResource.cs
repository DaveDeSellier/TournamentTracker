using System.ComponentModel.DataAnnotations;

namespace TournamentTracker.API.Models
{
    public class PersonResource
    {

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string EmailAddress { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; } = null!;

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
