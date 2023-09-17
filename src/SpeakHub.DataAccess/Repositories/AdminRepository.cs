using Microsoft.EntityFrameworkCore;
using SpeakHub.DataAccess.DbContexts;
using SpeakHub.DataAccess.Interfaces;
using SpeakHub.DataAccess.Repositories.Common;
using SpeakHub.Domain.Entities.Admins;

namespace SpeakHub.DataAccess.Repositories
{
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        public AdminRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
        public async Task<Admin?> GetByEmailAsync(string email)
            => await _dbContext.Admins.FirstOrDefaultAsync(x => x.Email == email);
    }
}