using SpeakHub.Service.Common.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SpeakHub.Service.Dtos.Users
{
    public class UserResetPasswordDto
    {
        [Required(ErrorMessage = "Email is required!"), EmailAttribute]
        public string Email { get; set; } = string.Empty;

        [Required]
        public int Code { get; set; }

        [Required, StrongPassword]
        public string Password { get; set; } = string.Empty;
    }
}
