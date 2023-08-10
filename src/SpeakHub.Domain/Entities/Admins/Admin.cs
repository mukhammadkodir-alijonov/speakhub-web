using SpeakHub.Domain.Common;
using SpeakHub.Domain.Entities.Tweets;
using SpeakHub.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakHub.Domain.Entities.Admins
{
    public class Admin : Humen
    {
        public string AdminAction { get; set; } = string.Empty;
        public DateTime ActionDate { get; set; }
        public Role AdminRole { get; set; } = Role.Admin;
        public string PasswordHash { get; set; } = string.Empty;

        public string Salt { get; set; } = string.Empty;
        public long TweetId { get; set; }
        public virtual Tweet Tweet { get; set; } = default!;
    }
}
