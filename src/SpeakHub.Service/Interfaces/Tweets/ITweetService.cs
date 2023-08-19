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
        public Task<List<TweetViewModel>> GetAllByIdAsync(int id);
        public Task<bool> CreateTweetAsync(int id, TweetDto tweetDto);
        public Task<bool> UpdateTweetAsync(int id,TweetDto tweetDto);
        public Task<bool> DeleteTweetAsync(int id);
        public Task<List<LikesPerTweetViewModel>> GetAllLikeByTweetAsync(int tweetId);
    }
}
