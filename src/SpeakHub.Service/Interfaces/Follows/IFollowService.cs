namespace SpeakHub.Service.Interfaces.Follows
{
    public interface IFollowService
    {
        public Task<bool> FollowAsync(int userId);
        public Task<bool> UnFollowAsync(int userId);
    }
}
