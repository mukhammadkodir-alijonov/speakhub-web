using SpeakHub.Service.Dtos.Tweets;

namespace SpeakHub.Service.Interfaces.Comments
{
    public interface ICommentService
    {
        public Task<bool> CreateCommentAsync(int id, TweetDto tweetDto);
    }
}
