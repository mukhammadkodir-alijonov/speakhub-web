using SpeakHub.Service.Common.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SpeakHub.Service.Dtos.Accounts
{
    public class AccountRegisterDto : AccountLoginDto
    {
        [Required(ErrorMessage = "Enter a PhoneNumber!")]
        [PhoneNumber]
        public string PhoneNumber { get; set; } = String.Empty;

        [Required(ErrorMessage = "Enter a name!")]
        public string FirstName { get; set; } = String.Empty;

        [Required(ErrorMessage = "Enter a surname!")]
        public string LastName { get; set; } = String.Empty;
        [Required(ErrorMessage ="Select a option")]
        public string Gender { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
    }
}
