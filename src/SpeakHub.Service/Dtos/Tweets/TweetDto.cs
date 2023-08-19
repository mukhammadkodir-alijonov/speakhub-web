using SpeakHub.Domain.Common;
using SpeakHub.Domain.Entities.Tweets;
using SpeakHub.Service.Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakHub.Service.Dtos.Tweets
{
    public class TweetDto : Auditable
    {
        [TweetCheck]
        public string TweetText { get; set; } = string.Empty;
        [TweetCheck]
        public string EditTweetText { get; set; } = string.Empty;
    }
}
