using SpeakHub.Domain.Entities.Users;

namespace SpeakHub.Domain.Entities.Followers
{
    public class Follow : Human
    {
        public uint FollowingCount { get; set; }
        public uint FollowerCount { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; } = default!;
    }
}
