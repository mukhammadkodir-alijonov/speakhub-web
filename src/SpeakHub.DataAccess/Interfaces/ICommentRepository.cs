using SpeakHub.DataAccess.Interfaces.Common;
using SpeakHub.Domain.Entities.Comments;
using SpeakHub.Domain.Entities.Likes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakHub.DataAccess.Interfaces
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
    }
}
