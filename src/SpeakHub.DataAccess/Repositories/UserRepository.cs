using SpeakHub.DataAccess.DbContexts;
using SpeakHub.DataAccess.Interfaces;
using SpeakHub.DataAccess.Repositories.Common;
using SpeakHub.Domain.Entities.Users;

namespace SpeakHub.DataAccess.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}