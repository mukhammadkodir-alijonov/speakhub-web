using SpeakHub.Domain.Common;
using SpeakHub.Service.Common.Attributes;

namespace SpeakHub.Service.Dtos.Tweets
{
    public class TweetDto : Auditable
    {
        [TweetCheck]
        public string TweetText { get; set; } = string.Empty;
        [TweetCheck]
        public string EditTweetText { get; set; } = string.Empty;
        public string TweetSave { get; set; } = string.Empty;
    }
}
