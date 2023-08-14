using RegistanFerghanaLC.Service.Common.Utils;
using SpeakHub.Service.Dtos.Tweets;
using SpeakHub.Service.ViewModels.TweetViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakHub.Service.Interfaces.Tweets
{
    public interface ITweetService
    {
        public Task<PagedList<TweetViewModel>> GetAllByIdAsync(int id, PaginationParams @params);
        public Task<bool> CreateTweetAsync(TweetDto tweetDto);
        public Task<bool> UpdateTweetAsync(TweetDto tweetDto);
        public Task<bool> DeleteTweetAsync(int id);
    }
}
