using SpeakHub.Service.Dtos.Tweets;
using SpeakHub.Service.ViewModels.TweetViewModels;

namespace SpeakHub.Service.Interfaces.Tweets
{
    public interface ITweetService
    {
        public Task<List<TweetViewModel>> GetAllByIdAsync(int id);
        public Task<bool> CreateTweetAsync(TweetDto tweetDto);
        public Task<bool> UpdateTweetAsync(int id, EditTweetDto editTweetDto);
        public Task<bool> DeleteTweetAsync(int id);
        //public Task<bool> SaveTweetAsync(int tweetId, SaveTweetDto saveTweetDto);
        public Task<List<LikesPerTweetViewModel>> GetAllLikeByTweetAsync(int tweetId);
    }
}
