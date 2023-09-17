using Microsoft.EntityFrameworkCore;
using SpeakHub.DataAccess.Interfaces.Common;
using SpeakHub.Domain.Entities.Tweets;
using SpeakHub.Service.Common.Exceptions;
using SpeakHub.Service.Common.Helpers;
using SpeakHub.Service.Dtos.Tweets;
using SpeakHub.Service.Interfaces.Tweets;
using SpeakHub.Service.ViewModels.TweetViewModels;
using System.Net;

namespace SpeakHub.Service.Services.TweetService
{
    public class TweetService : ITweetService
    {
        private readonly IUnitOfWork _repository;
        public TweetService(IUnitOfWork unitOfWork)
        {
            this._repository = unitOfWork;
        }
        public async Task<List<TweetViewModel>> GetAllByIdAsync(int id)
        {
            var query = await (from tweets in _repository.Tweets.GetAll().Where(t => t.UserId == id).OrderByDescending(x => x.CreatedAt)
                               let like = _repository.Likes.GetAll().Where(t => t.TweetId == tweets.Id).ToList()
                               let comment = _repository.Comments.GetAll().Where(t => t.TweetId == tweets.Id).ToList()
                               let likeCount = like.Count()
                               let commentCount = comment.Count()
                               select new TweetViewModel
                               {
                                   Id = tweets.Id,
                                   TweetText = tweets.TweetText,
                                   LikeCount = likeCount,
                                   CommentCount = commentCount
                               }).ToListAsync();
            return query;
        }
        public async Task<bool> CreateTweetAsync(int tweetId, TweetDto tweetDto)
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
            else throw new StatusCodeException(HttpStatusCode.BadRequest, "This details for Tweet are already exist!");
        }
        public async Task<bool> UpdateTweetAsync(int id, EditTweetDto editTweetDto)
        {
            var editTweet = await _repository.Tweets.FirstOrDefault(x => x.Id == id);
            if (editTweet != null)
            {
                _repository.Tweets.TrackingDeteched(editTweet);
                editTweet.LastUpdatedAt = DateTime.Now;
                editTweet.EditTweetText = editTweetDto.EditTweetText;
                editTweet.Id = id;
                _repository.Tweets.Update(editTweet.Id, editTweet);
                var result = await _repository.SaveChangesAsync();
                return result > 0;
            }
            else throw new StatusCodeException(HttpStatusCode.BadRequest, "Tweet not found");
        }
        public async Task<bool> DeleteTweetAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid tweet ID");
            }

            var tweetToDelete = await _repository.Tweets.FindByIdAsync(id);

            if (tweetToDelete == null)
            {
                throw new StatusCodeException(HttpStatusCode.NotFound, "Tweet not found");
            }

            _repository.Tweets.Delete(id); // Pass the ID of the tweet to delete
            var result = await _repository.SaveChangesAsync();
            return result > 0;
        }
        public async Task<bool> SaveTweetAsync(int tweetId, SaveTweetDto saveTweetDto)
        {
            var savetweet = await _repository.Tweets.FirstOrDefault(x => x.Id == tweetId);
            if (savetweet == null)
            {
                var entity = new Tweet
                {
                    CreatedAt = TimeHelper.GetCurrentServerTime(),
                    SaveTweet = saveTweetDto.TweetSave,
                    LastUpdatedAt = TimeHelper.GetCurrentServerTime(),
                };
                var repo = _repository.Tweets.Add(entity);
                var rresult = await _repository.SaveChangesAsync();
                return rresult > 0;
            }
            else throw new StatusCodeException(HttpStatusCode.BadRequest, "This details for TweetSave are already exist!");
        }
        public async Task<List<LikesPerTweetViewModel>> GetAllLikeByTweetAsync(int tweetId)
        {
            var query = await (from like in _repository.Likes.GetAll().Where(x => x.TweetId == tweetId).OrderByDescending(x => x.CreatedAt)
                               join user in _repository.Users.GetAll()
                               on like.UserId equals user.Id
                               select new LikesPerTweetViewModel()
                               {
                                   LikeId = like.Id,
                                   FirstName = user.FirstName,
                                   LastName = user.LastName,
                                   UserName = user.Username
                               }).ToListAsync();
            return query;
        }

    }
}
