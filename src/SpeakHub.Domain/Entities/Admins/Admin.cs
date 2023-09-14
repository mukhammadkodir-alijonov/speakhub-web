using SpeakHub.Domain.Enums;

namespace SpeakHub.Domain.Entities.Admins
{
    public class Admin : Human
    {
        public string AdminAction { get; set; } = string.Empty;
        public DateTime ActionDate { get; set; }
        public Role AdminRole { get; set; } = Role.Admin;
        public string PasswordHash { get; set; } = string.Empty;

        public string Salt { get; set; } = string.Empty;
        /*public int TweetId { get; set; }
        public virtual Tweet Tweet { get; set; } = default!;*/
    }
}
