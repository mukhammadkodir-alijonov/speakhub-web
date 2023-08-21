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
        public Task<bool> FollowAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UnFollowAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
