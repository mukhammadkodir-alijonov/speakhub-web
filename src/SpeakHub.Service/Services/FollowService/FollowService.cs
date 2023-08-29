using SpeakHub.DataAccess.Interfaces.Common;
using SpeakHub.Service.Interfaces.Follows;

namespace SpeakHub.Service.Services.FollowService
{
    public class FollowService : IFollowService
    {
        private readonly IUnitOfWork _repository;

        public FollowService(IUnitOfWork unitOfWork)
        {
            this._repository = unitOfWork;
        }
        public async Task<bool> FollowAsync(int _userId1, int _userId2)
        {
            var isUpdateDbOk = await _repository.Follows.FollowAsync(_userId1, _userId2);
            await _repository.SaveChangesAsync();

            return isUpdateDbOk;
        }

        public async Task<bool> UnFollowAsync(int _userId1, int _userId2)
        {
            var isUpdateDbOk = await _repository.Follows.UnfollowAsync(_userId1, _userId2);
            await _repository.SaveChangesAsync();

            return isUpdateDbOk;
        }
    }
}
