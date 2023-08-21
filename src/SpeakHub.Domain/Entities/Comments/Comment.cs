using SpeakHub.Domain.Common;
using SpeakHub.Domain.Entities.Tweets;
using SpeakHub.Domain.Entities.Users;

namespace SpeakHub.Domain.Entities.Comments
{
    public class Comment : Auditable
    {
        public string CommentText { get; set; } = string.Empty;
        public int TweetId { get; set; }
        public virtual Tweet Tweet { get; set; } = default!;
        public int UserId { get; set; }
        public virtual User User { get; set; } = default!;
    }
}
