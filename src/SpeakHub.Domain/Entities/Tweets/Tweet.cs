using SpeakHub.Domain.Common;
using SpeakHub.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakHub.Domain.Entities.Tweets
{
    public class Tweet : Auditable
    {
        public string TweetText { get; set; } = string.Empty;
        public string EditTweetText { get; set; } = string.Empty;
        public int UserId { get; set; }
        public virtual User User { get; set; } = default!;
    }
}
