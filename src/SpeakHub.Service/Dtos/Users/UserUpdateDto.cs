using Microsoft.AspNetCore.Http;
using SpeakHub.Service.Common.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SpeakHub.Service.Dtos.Users
{
    public class UserUpdateDto
    {
        [Required, MaxLength(30), MinLength(3)]
        public string FirstName { get; set; } = string.Empty;

        [Required, MaxLength(30), MinLength(3)]
        public string LastName { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false), PhoneNumber]
        public string PhoneNumber { get; set; } = string.Empty;

        public IFormFile? Image { get; set; }
    }
}
