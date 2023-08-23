namespace SpeakHub.Service.ViewModels.UserViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string? Image { get; set; }

        public string Email { get; set; } = string.Empty;
    }
}
