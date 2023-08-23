using System.ComponentModel.DataAnnotations;

namespace SpeakHub.Service.Dtos.Users
{
    public class UserDeleteDto
    {
        [Required(ErrorMessage = "Enter your password")]
        public string Password { get; set; } = default!;
    }
}
