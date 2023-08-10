using SpeakHub.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakHub.Domain.Entities.Users
{
    public class UserProfile : Humen
    {
        public string FullName { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public long FollowersCount { get; set; }
        public long FollowingCount { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; } = default!;
    }
}
