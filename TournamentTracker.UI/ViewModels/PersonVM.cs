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

        public PersonVM(Person person)
        {
            Id = person.Id;
            FirstName = person.FirstName.Trim();
            LastName = person.LastName;
            EmailAddress = person.EmailAddress;
            PhoneNumber = person.PhoneNumber;
        }

        public static Person CreatePerson(PersonVM vm)
        {
            return new Person() { FirstName = vm.FirstName, LastName = vm.LastName, EmailAddress = vm.EmailAddress, PhoneNumber = vm.PhoneNumber };

        }

    }
}
