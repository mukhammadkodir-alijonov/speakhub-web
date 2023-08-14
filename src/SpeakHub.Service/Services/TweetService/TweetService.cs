using RegistanFerghanaLC.Service.Common.Exceptions;
using RegistanFerghanaLC.Service.Common.Utils;
using SpeakHub.DataAccess.Interfaces.Common;
using SpeakHub.Domain.Entities.Tweets;
using SpeakHub.Service.Dtos.Tweets;
using SpeakHub.Service.Interfaces.Tweets;
using SpeakHub.Service.ViewModels.TweetViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakHub.Service.Services.TweetService
{
    public class TweetService : ITweetService
    {
        private readonly IUnitOfWork _repository;
        private readonly ITweetService _tweetService;

        public TweetService(IUnitOfWork unitOfWork, ITweetService tweetService)
        {
            this._repository = unitOfWork;
            this._tweetService = tweetService;
        }
        public Task<PagedList<TweetViewModel>> GetAllByIdAsync(int id, PaginationParams @params)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> CreateTweetAsync(TweetDto tweetDto)
        {
            var newTweet = new Tweet
            {
                Id = tweetDto.Id,
                TweetText = tweetDto.TweetText,
                CreatedAt = DateTime.Now,
            };
            _repository.Tweets.Add(newTweet);
            var result = await _repository.SaveChangesAsync();
            return result > 0;
        }
        public Task<bool> UpdateTweetAsync(TweetDto tweetDto)
        {
            throw new NotImplementedException();
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
                throw new StatusCodeException(System.Net.HttpStatusCode.NotFound, "Tweet not found");
            }

            _repository.Tweets.Delete(id); // Pass the ID of the tweet to delete
            var result = await _repository.SaveChangesAsync();
            return result > 0;
        }
    }
}
