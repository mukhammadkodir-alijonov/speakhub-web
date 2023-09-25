using SpeakHub.DataAccess.Interfaces.Common;
using SpeakHub.Domain.Entities.Comments;
using SpeakHub.Service.Common.Exceptions;
using SpeakHub.Service.Common.Helpers;
using SpeakHub.Service.Dtos.Comments;
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
        public async Task<bool> CreateCommentAsync(CommentDto commentDto)
        {
                var entity = new Comment()
                {
                    TweetId = commentDto.TweetId,
                    UserId = commentDto.UserId,
                    CreatedAt = TimeHelper.GetCurrentServerTime(),
                    CommentText = commentDto.CommentText,
                    //UserId = HttpContextHelper.UserId
                };
                var res = _repository.Comments.Add(entity);
                var result = await _repository.SaveChangesAsync();
                return result > 0;
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
