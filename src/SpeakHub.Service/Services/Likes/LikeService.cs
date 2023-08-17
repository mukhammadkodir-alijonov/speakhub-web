using Microsoft.EntityFrameworkCore;
using RegistanFerghanaLC.Service.Common.Exceptions;
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
                    TweetId = tweetId
                };

                _repository.Likes.Add(newLike);
                await _repository.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UnlikeAsync(int likeId,int userId, int tweetId)
        {
            var unlike = _repository.Likes.GetAll().Where(x=>x.TweetId == tweetId).Count();
            if (unlike != null)
            {
                _repository.Likes.Delete(likeId);
                var tweet = await _repository.Tweets.FindByIdAsync(tweetId);
                return true;
            }
            return false;
        }

        /*public async Task<bool> UnlikeAsync(int tweetId)
        {
            var tweet = await _repository.Tweets.FindByIdAsync(tweetId);
            //_repository.Tweets.TrackingDeteched(tweet);
            if (tweet?.LikeCount != null)
            {
                tweet.LikeCount--;
                _repository.Tweets.Update(tweetId,tweet); // Use UpdateAsync here
                await _repository.SaveChangesAsync();
                return true; // Unliked
            }
            return false;
        }*/
    }
}
