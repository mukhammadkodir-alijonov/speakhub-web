using SpeakHub.Domain.Entities.Tweets;
using SpeakHub.Service.Common.Attributes;
using SpeakHub.Service.Dtos.Tweets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakHub.Service.ViewModels.TweetViewModels
{
    public class TweetViewModel
    {
        public int Id { get; set; }
        public string TweetText { get; set; } = string.Empty;
        public string EditTweetText { get; set; } = string.Empty;
        public int likeCount { get; set; }
        /*public static implicit operator TweetViewModel(Tweet model)
        {
            return new TweetViewModel
            {
                Id = model.Id,
                TweetText = model.TweetText,
                EditTweetText = model.EditTweetText
            };
        }*/
    }
}
