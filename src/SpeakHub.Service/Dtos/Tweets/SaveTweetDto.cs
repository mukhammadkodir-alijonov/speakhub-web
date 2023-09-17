using SpeakHub.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakHub.Service.Dtos.Tweets
{
    public class SaveTweetDto : Auditable
    {
        public string TweetSave { get; set; } = string.Empty;
    }
}
