using SpeakHub.Domain.Common;
using SpeakHub.Domain.Entities.Users;

namespace SpeakHub.Domain.Entities.Followers
{
    public class Following : Auditable
    {
        public int UserId { get; set; }
        public virtual UserProfile? User { get; set; }
    }
}
