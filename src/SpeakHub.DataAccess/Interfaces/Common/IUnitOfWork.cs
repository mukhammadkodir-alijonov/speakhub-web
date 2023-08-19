using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakHub.DataAccess.Interfaces.Common
{
    public interface IUnitOfWork
    {
        public IAdminRepository Admins { get; }
        public ITweetRepository Tweets { get; }
        public ILikeRepository Likes { get; }
        public ICommentRepository Comments { get; }
        public IUserProfileRepository UserProfiles { get; }
        public IUserRepository Users { get; }
        public Task<int> SaveChangesAsync();
        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}