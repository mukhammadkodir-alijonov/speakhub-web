using SpeakHub.DataAccess.Interfaces.Common;
using SpeakHub.Domain.Entities.Tweets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakHub.DataAccess.Interfaces
{
    public interface ITweetRepository : IGenericRepository<Tweet>
    {
    }
}