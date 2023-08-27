using Microsoft.EntityFrameworkCore;
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
            var followings = appDbContext
                .Follows
                .Where(w => w.UserId == 1)
                .Include(i => i.Follower)
                .AsNoTracking()
                .ToListAsync();

            var followers = appDbContext.Follows.Where(w => w.FollowerId == 1).Include(i => i.Follower).AsNoTracking().ToListAsync();
        }
    }
}
