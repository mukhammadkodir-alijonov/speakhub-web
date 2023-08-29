using SpeakHub.DataAccess.Interfaces.Common;
using SpeakHub.Domain.Entities.Tweets;
using SpeakHub.Service.Common.Exceptions;
using SpeakHub.Service.Common.Helpers;
using SpeakHub.Service.Dtos.Tweets;
using SpeakHub.Service.Interfaces.Comments;
using System.Net;

namespace SpeakHub.Service.Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _repository;
        public CommentService(IUnitOfWork unitOfWork)
        {
            this._repository = unitOfWork;
        }
        public async Task<bool> CreateCommentAsync(int tweetId, TweetDto tweetDto)
        {
            var check = await _repository.Tweets.FirstOrDefault(x => x.Id == tweetId);
            if (check == null)
            {
                var entity = new Tweet()
                {
                    Id = tweetDto.Id,
                    CreatedAt = TimeHelper.GetCurrentServerTime(),
                    LastUpdatedAt = TimeHelper.GetCurrentServerTime(),
                    TweetText = tweetDto.TweetText,
                };
                var res = _repository.Tweets.Add(entity);
                var result = await _repository.SaveChangesAsync();
                return result > 0;
            }
            else throw new StatusCodeException(HttpStatusCode.BadRequest, "This details for Comment are already exist!");
        }

        public async Task<bool> DeleteCommentAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid tweet ID");
            }

            var commentToDelete = await _repository.Comments.FindByIdAsync(id);

            if (commentToDelete == null)
            {
                throw new StatusCodeException(HttpStatusCode.NotFound, "Tweet not found");
            }

            _repository.Comments.Delete(id); // Pass the ID of the tweet to delete
            var result = await _repository.SaveChangesAsync();
            return result > 0;
        }
    }
}
