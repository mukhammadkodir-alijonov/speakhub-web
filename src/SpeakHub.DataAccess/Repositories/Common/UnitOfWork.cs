using Microsoft.EntityFrameworkCore.ChangeTracking;
using SpeakHub.DataAccess.DbContexts;
using SpeakHub.DataAccess.Interfaces;
using SpeakHub.DataAccess.Interfaces.Common;
using SpeakHub.Domain.Entities.Tweets;
using SpeakHub.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakHub.DataAccess.Repositories.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContexr;
        public ILikeRepository Likes { get; }
        public IAdminRepository Admins { get; }
        public ITweetRepository Tweets { get; }
        public IUserProfileRepository UserProfiles { get; }
        public IUserRepository Users { get; }

        public UnitOfWork(AppDbContext dbContext)
        {
            this._dbContexr = dbContext;

            Admins = new AdminRepository(_dbContexr);
            Tweets = new TweetRepository(_dbContexr);
            UserProfiles = new UserProfileRepository(_dbContexr);
            Users = new UserRepository(_dbContexr);
        }
        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
            => _dbContexr.Entry(entity);

        public async Task<int> SaveChangesAsync()
            => await _dbContexr.SaveChangesAsync();
    }
}