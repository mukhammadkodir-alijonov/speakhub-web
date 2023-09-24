using SpeakHub.Service.Dtos.Comments;
using SpeakHub.Service.Dtos.Tweets;

namespace SpeakHub.Service.Interfaces.Comments
{
    public interface ICommentService
    {
        public Task<bool> CreateCommentAsync(CommentDto commentDto);
        public Task<bool> DeleteCommentAsync(int id);
    }
}
