using SpeakHub.DataAccess.Interfaces.Common;
using SpeakHub.Domain.Entities.Users;

namespace SpeakHub.DataAccess.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
    }
}