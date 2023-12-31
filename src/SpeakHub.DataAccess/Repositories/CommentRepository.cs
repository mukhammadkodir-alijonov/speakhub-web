﻿using SpeakHub.DataAccess.DbContexts;
using SpeakHub.DataAccess.Interfaces;
using SpeakHub.DataAccess.Repositories.Common;
using SpeakHub.Domain.Entities.Comments;

namespace SpeakHub.DataAccess.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
