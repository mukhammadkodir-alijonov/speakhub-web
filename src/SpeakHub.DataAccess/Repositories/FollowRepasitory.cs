using SpeakHub.DataAccess.DbContexts;
using SpeakHub.DataAccess.Interfaces;
using SpeakHub.DataAccess.Repositories.Common;
using SpeakHub.Domain.Entities.Followers;

namespace SpeakHub.DataAccess.Repositories
{
    internal class FollowRepasitory : GenericRepository<Follow>, IFollowRepasitory
    {
        public FollowRepasitory(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
