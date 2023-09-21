using SpeakHub.Domain.Common;

namespace SpeakHub.Domain.Entities
{
    public class Human : Auditable
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string? Image { get; set; }

        public string Gender { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; }

        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

    }
}
