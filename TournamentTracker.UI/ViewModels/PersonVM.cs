using System.ComponentModel.DataAnnotations;
using TournamentTracker.Core.Models;

namespace TournamentTracker.UI.ViewModels
{
    public class PersonVM
    {

        public int Id { get; private set; }

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string EmailAddress { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; } = null!;

        public Person Person { get; } = new();

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public PersonVM()
        {

        }

        public PersonVM(string firstName, string lastName, string emailAddress, string phoneNumber)
        {
            Person = new()
            {
                FirstName = firstName.Trim(),
                LastName = lastName.Trim(),
                EmailAddress = emailAddress.Trim(),
                PhoneNumber = phoneNumber.Trim()

            };
        }

        public PersonVM(Person person)
        {
            Id = person.Id;
            FirstName = person.FirstName;
            LastName = person.LastName;
            EmailAddress = person.EmailAddress;
            PhoneNumber = person.PhoneNumber;
        }

    }
}
