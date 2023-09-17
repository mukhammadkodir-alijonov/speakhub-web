using SpeakHub.DataAccess.Interfaces.Common;
using SpeakHub.Domain.Entities.Admins;

namespace SpeakHub.DataAccess.Interfaces
{
    public interface IAdminRepository : IGenericRepository<Admin>
    {
        public Task<Admin?> GetByEmailAsync(string email);
    }
}