using SpeakHub.Service.Common.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SpeakHub.Service.Dtos.Accounts
{
    public class AccountLoginDto
    {
        [Required(ErrorMessage = "Enter an Email!")]
        [Email]
        public string Email { get; set; } = String.Empty;

        [Required(ErrorMessage = "Enter a password!")]
        [StrongPassword]
        public string Password { get; set; } = String.Empty;
    }
}
