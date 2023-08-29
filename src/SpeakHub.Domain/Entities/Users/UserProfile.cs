using SpeakHub.Domain.Entities.Followers;

namespace SpeakHub.Domain.Entities.Users
{
    public class UserProfile : Human
    {
        public string FullName { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public IList<Follower> Followers { get; private set; } = new List<Follower>();
        public IList<Following> Followings { get; private set; } = new List<Following>();
        public int UserId { get; set; }
        public virtual User User { get; set; } = default!;
    }
}
