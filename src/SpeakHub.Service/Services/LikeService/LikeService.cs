using SpeakHub.Service.Common.Helpers;
using SpeakHub.DataAccess.Interfaces.Common;
using SpeakHub.Domain.Entities.Likes;
using SpeakHub.Service.Interfaces.Likes;

namespace SpeakHub.Service.Services.Likes
{
    public class LikeService : ILikeService
    {
        private readonly IUnitOfWork _repository;

        public LikeService(IUnitOfWork unitOfWork)
        {
            this._repository = unitOfWork;
        }

        public async Task<bool> LikeAsync(int userId, int tweetId)
        {
            var like = await _repository.Likes.FirstOrDefault(l => l.TweetId == tweetId && l.UserId == userId);
            if (like == null)
            {
                var newLike = new Like
                {
                    UserId = userId,
                    TweetId = tweetId,
                    CreatedAt = TimeHelper.GetCurrentServerTime(),
                };
                _repository.Likes.Add(newLike);
                return 0 < await _repository.SaveChangesAsync();
            }
            return false;
        }
        public async Task<bool> UnlikeAsync(int userId, int tweetId)
        {
            var unlike = _repository.Likes.FirstOrDefault(x => x.TweetId == tweetId && x.UserId == userId);
            if (unlike != null)
            {
                _repository.Likes.Delete(unlike.Id);
                return 0 < await _repository.SaveChangesAsync();
            }
            else { return false; }
        }
    }
}
