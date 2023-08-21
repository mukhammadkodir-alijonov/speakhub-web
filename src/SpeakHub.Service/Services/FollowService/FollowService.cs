using SpeakHub.DataAccess.Interfaces.Common;
using SpeakHub.Domain.Entities.Users;
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
        public async Task<bool> FollowAsync(int userId)
        {
            var follow = await _repository.Follows.FirstOrDefault(x => x.UserId == userId);
            if (follow == null)
            {
                var newfollower = new User
                {

                };
            }
        }

        public Task<bool> UnFollowAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
