using SpeakHub.Domain.Common;
using SpeakHub.Service.Common.Attributes;

namespace SpeakHub.Service.Dtos.Tweets
{
    public class TweetDto
    {
        public int Id { get; set; }
        [TweetCheck]
        public string TweetText { get; set; } = string.Empty;
    }
}
