using SpeakHub.DataAccess.DbContexts;
using SpeakHub.DataAccess.Interfaces;
using SpeakHub.DataAccess.Repositories.Common;
using SpeakHub.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakHub.DataAccess.Repositories
{
    public class UserProfileRepository : GenericRepository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}