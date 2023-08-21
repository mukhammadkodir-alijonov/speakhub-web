namespace SpeakHub.Service.Interfaces.Likes
{
    public interface ILikeService
    {
        public Task<bool> LikeAsync(int userId, int tweetId);
        public Task<bool> UnlikeAsync(int userId, int tweetId);
    }
}
