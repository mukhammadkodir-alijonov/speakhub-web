using SpeakHub.Domain.Common;
using SpeakHub.Domain.Entities.Users;

namespace SpeakHub.Domain.Entities.Tweets
{
    public class Tweet : Auditable
    {
        public string TweetText { get; set; } = string.Empty;
        public string EditTweetText { get; set; } = string.Empty;
        public string SaveTweet { get; set; } = string.Empty;
        public int UserId { get; set; } 
        public virtual User User { get; set; } = default!;
    }
}
