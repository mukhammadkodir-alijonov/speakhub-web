using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpeakHub.Domain.Common;
using SpeakHub.Domain.Entities.Admins;
using System.ComponentModel.DataAnnotations;

namespace SpeakHub.Service.Dtos.Admins
{
    public class AdminUpdateDto : BaseEntity
    {
        [Required(ErrorMessage = "First Name Required")]
        public string FirstName { get; set; } = String.Empty;
        [Required(ErrorMessage = "Last Name Required")]
        public string LastName { get; set; } = String.Empty;
        public IFormFile Image { get; set; } = default!;
        public string? ImagePath { get; set; }

        [Required(ErrorMessage = "Phone Number Required")]
        [Phone(ErrorMessage = "The phone number was entered incorrectly")]
        [Remote("IsPhoneAvailable", "Check", HttpMethod = "POST", ErrorMessage = "A phone number with this name has already been registered!")]//changed
        public string PhoneNumber { get; set; } = String.Empty;
        public DateTime BirthDate { get; set; }

        public static implicit operator Admin(AdminUpdateDto dto)
        {
            return new Admin()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Image = dto.ImagePath,
                PhoneNumber = dto.PhoneNumber,
                BirthDate = dto.BirthDate,
            };
        }
    }
}
