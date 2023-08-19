using Microsoft.EntityFrameworkCore;
using RegistanFerghanaLC.Service.Common.Exceptions;
using RegistanFerghanaLC.Service.Common.Helpers;
using SpeakHub.DataAccess.Interfaces;
using SpeakHub.DataAccess.Interfaces.Common;
using SpeakHub.Domain.Entities.Likes;
using SpeakHub.Domain.Entities.Tweets;
using SpeakHub.Service.Dtos.Tweets;
using SpeakHub.Service.Interfaces.Likes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SpeakHub.Service.Services.Likes
{
    public class LikeService : ILikeService
    {
        private readonly IUnitOfWork _repository;

        public LikeService(IUnitOfWork unitOfWork)
        {
            this._repository = unitOfWork;
        }

        public async Task<bool> LikeAsync(int userId, int tweetId)
        {
            var existingLike = await _repository.Likes.FirstOrDefault(l => l.TweetId == tweetId && l.UserId == userId);
            if (existingLike == null)
            {
                var newLike = new Like
                {
                    UserId = userId,
                    TweetId = tweetId,
                    CreatedAt = TimeHelper.GetCurrentServerTime(),
                };
                _repository.Likes.Add(newLike);
                return 0 < await _repository.SaveChangesAsync();
            }
            return false;
        }
        public async Task<bool> UnlikeAsync(int likeId,int userId, int tweetId)
        {
            var unlike = _repository.Likes.FirstOrDefault(x => x.TweetId == tweetId && x.UserId == userId);
            if(unlike != null)
            {
                _repository.Likes.Delete(unlike.Id);
                return 0 < await _repository.SaveChangesAsync();
            }
            else { return false; }
        }
    }
}
