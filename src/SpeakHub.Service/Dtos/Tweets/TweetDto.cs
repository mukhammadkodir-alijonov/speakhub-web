using SpeakHub.Domain.Common;
using SpeakHub.Service.Common.Attributes;

namespace SpeakHub.Service.Dtos.Tweets
{
    public class TweetDto : Auditable
    {
        [TweetCheck]
        public string TweetText { get; set; } = string.Empty;
    }
}
