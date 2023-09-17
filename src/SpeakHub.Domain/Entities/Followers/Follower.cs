using SpeakHub.Domain.Common;
using SpeakHub.Domain.Entities.Users;

namespace SpeakHub.Domain.Entities.Followers
{
    public class Follower : Auditable
    {
        public int UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
