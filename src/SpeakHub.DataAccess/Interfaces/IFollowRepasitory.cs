using SpeakHub.DataAccess.Interfaces.Common;
using SpeakHub.Domain.Entities.Followers;

namespace SpeakHub.DataAccess.Interfaces
{
    public interface IFollowRepasitory : IGenericRepository<Follower>
    {
        /*        public Task<List<Follower>> GetFollowingsAsync(int userId);
                public Task<List<Follower>> GetFollowersAsync(int followerId);*/
        public Task<bool> FollowAsync(int _userId1, int _userId2);
        public Task<bool> UnfollowAsync(int _userId1, int _userId2);
    }
}
