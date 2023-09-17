using SpeakHub.Domain.Common;
using SpeakHub.Service.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakHub.Service.Dtos.Tweets
{
    public class EditTweetDto : Auditable
    {
        [TweetCheck]
        public string EditTweetText { get; set; } = string.Empty;
    }
}
