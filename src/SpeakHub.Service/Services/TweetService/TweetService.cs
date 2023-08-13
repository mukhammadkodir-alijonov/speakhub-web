using RegistanFerghanaLC.Service.Common.Utils;
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
        public Task<bool> CreateTweetAsync(TweetDto tweetDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTweetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedList<TweetViewModel>> GetAllByIdAsync(int id, PaginationParams @params)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTweetAsync(TweetDto tweetDto)
        {
            throw new NotImplementedException();
        }
    }
}
