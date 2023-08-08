using SpeakHub.DataAccess.Interfaces.Common;
using SpeakHub.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakHub.DataAccess.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
    }
}
