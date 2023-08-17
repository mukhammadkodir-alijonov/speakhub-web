using SpeakHub.Service.Dtos.Tweets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakHub.Service.Interfaces.Likes
{
    public interface ILikeService
    {
        public Task<bool> LikeAsync(int userId, int tweetId);
        public Task<bool> UnlikeAsync(int likeId,int userId, int tweetId);
    }
}
