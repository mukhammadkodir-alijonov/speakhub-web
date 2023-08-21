using SpeakHub.DataAccess.Interfaces.Common;
using SpeakHub.Domain.Entities.Tweets;

namespace SpeakHub.DataAccess.Interfaces
{
    public interface ITweetRepository : IGenericRepository<Tweet>
    {
    }
}