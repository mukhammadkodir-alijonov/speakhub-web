using SpeakHub.Domain.Enums;

namespace SpeakHub.Service.ViewModels.UserViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public Role UserRole { get; set; } = Role.Admin;

        public string? Image { get; set; }

        public string Email { get; set; } = string.Empty;
    }
}
