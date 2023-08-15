using DocumentFormat.OpenXml.Office2010.Excel;
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
using System.Net;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SpeakHub.Service.Services.TweetService
{
    public class TweetService : ITweetService
    {
        private readonly IUnitOfWork _repository;
        public TweetService(IUnitOfWork unitOfWork)
        {
            this._repository = unitOfWork;
        }
        public Task<PagedList<TweetViewModel>> GetAllByIdAsync(int id, PaginationParams @params)
        {
            var query = from tweets in _repository.Tweets.GetAll().Where(t => t.Id == id)
                        select new TweetViewModel
                        {
                            Id = tweets.Id,
                            TweetText = tweets.TweetText
                        };
            return PagedList<TweetViewModel>.ToPagedListAsync(query,@params);
        }
        public async Task<bool> CreateTweetAsync(int id)
        {
           var check = await _repository.Tweets.FirstOrDefault(x => x.Id == id);
            if (check == null)
            {
                var entity = new Tweet()
                {
                    Id = id,
                    CreatedAt = DateTime.Now,
                    LastUpdatedAt = DateTime.Now,
                    TweetText = string.Empty,
                };
                var res = _repository.Tweets.Add(entity);
                var result = await _repository.SaveChangesAsync();
                return result > 0;
            }
            else throw new StatusCodeException(HttpStatusCode.BadRequest, "This details for Tweet are already exist!");
        }
        public async Task<bool> UpdateTweetAsync(int id,TweetDto tweetDto)
        {
            var editTweet = await _repository.Tweets.FirstOrDefault(x=>x.Id ==id);
            if (editTweet != null)
            {
                _repository.Tweets.TrackingDeteched(editTweet);
                editTweet.LastUpdatedAt = DateTime.Now;
                editTweet.EditTweetText = tweetDto.EditTweetText;
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
                throw new StatusCodeException(System.Net.HttpStatusCode.NotFound, "Tweet not found");
            }

            _repository.Tweets.Delete(id); // Pass the ID of the tweet to delete
            var result = await _repository.SaveChangesAsync();
            return result > 0;
        }
    }
}
