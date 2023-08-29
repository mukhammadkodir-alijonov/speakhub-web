namespace SpeakHub.Service.Interfaces.Follows
{
    public interface IFollowService
    {
        public Task<bool> FollowAsync(int _userId1, int _userId2);
        public Task<bool> UnFollowAsync(int _userId1, int _userId2);
    }
}
