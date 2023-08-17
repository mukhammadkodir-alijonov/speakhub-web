using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakHub.Service.ViewModels.TweetViewModels
{
    public class LikesPerTweetViewModel
    {
        public int LikeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
}
