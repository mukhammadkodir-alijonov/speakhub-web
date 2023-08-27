namespace SpeakHub.Domain.Entities.Users
{
    public class UserProfile : Human
    {
        public string FullName { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public long FollowersCount { get; set; }
        public long FollowingCount { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; } = default!;
    }
}
