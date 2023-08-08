using SpeakHub.DataAccess.Interfaces.Common;
using SpeakHub.Domain.Entities.Admins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakHub.DataAccess.Interfaces
{
    public interface IAdminRepository : IGenericRepository<Admin>
    {
    }
}
