using System.ComponentModel.DataAnnotations;

namespace SpeakHub.Service.Dtos.Accounts
{
    public class AccountRegisterDto : AccountLoginDto
    {
        [Required(ErrorMessage = "Enter an Email!")]
        public string Email { get; set; } = String.Empty;

        [Required(ErrorMessage = "Enter a name!")]
        public string FirstName { get; set; } = String.Empty;

        [Required(ErrorMessage = "Enter a surname!")]
        public string LastName { get; set; } = String.Empty;
        public DateTime BirthDate { get; set; }
    }
}
