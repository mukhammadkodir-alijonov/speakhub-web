using RegistanFerghanaLC.Service.Common.Exceptions;
using SpeakHub.DataAccess.Interfaces.Common;
using SpeakHub.Domain.Entities.Tweets;
using SpeakHub.Service.Interfaces.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SpeakHub.Service.Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _repository;
        public CommentService(IUnitOfWork unitOfWork)
        {
            this._repository = unitOfWork;
        }
        public async Task<bool> CreateCommentAsync(int tweetId)
        {
            var check = await _repository.Tweets.FirstOrDefault(x => x.Id == tweetId);
            if (check == null)
            {
                var entity = new Tweet()
                {
                    Id = tweetId,
                    CreatedAt = DateTime.Now,
                    LastUpdatedAt = DateTime.Now,
                    TweetText = string.Empty,
                };
                var res = _repository.Tweets.Add(entity);
                var result = await _repository.SaveChangesAsync();
                return result > 0;
            }
            else throw new StatusCodeException(HttpStatusCode.BadRequest, "This details for Comment are already exist!");
        }
    }
}
