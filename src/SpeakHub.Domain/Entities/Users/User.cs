using SpeakHub.Domain.Entities.Followers;
using SpeakHub.Domain.Enums;

namespace SpeakHub.Domain.Entities.Users
{
    public class User : Human
    {
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Salt { get; set; } = string.Empty;
        public Role UserRole { get; set; } = Role.User;
        public StatusType Status { get; set; } = StatusType.Active;
        public IList<Follower> Followers { get; private set; } = new List<Follower>();
        public IList<Following> Followings { get; private set; } = new List<Following>();
    }
}
