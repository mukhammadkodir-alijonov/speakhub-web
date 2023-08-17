using SpeakHub.DataAccess.DbContexts;
using SpeakHub.DataAccess.Interfaces;
using SpeakHub.DataAccess.Repositories.Common;
using SpeakHub.Domain.Entities.Likes;

namespace SpeakHub.DataAccess.Repositories
{
    public class LikeRepository : GenericRepository<Like>, ILikeRepository
    {
        public LikeRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
