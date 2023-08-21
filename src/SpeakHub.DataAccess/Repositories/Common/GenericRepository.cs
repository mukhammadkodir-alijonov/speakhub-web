using SpeakHub.DataAccess.DbContexts;
using SpeakHub.DataAccess.Interfaces.Common;
using SpeakHub.Domain.Common;
using System.Linq.Expressions;

namespace SpeakHub.DataAccess.Repositories.Common
{
    public class GenericRepository<T> : BaseRepository<T>, IGenericRepository<T>
    where T : BaseEntity
    {
        public GenericRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public IQueryable<T> GetAll()
            => _dbSet;
        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
            => _dbSet.Where(predicate);
    }
}