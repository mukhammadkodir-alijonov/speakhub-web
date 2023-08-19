﻿using SpeakHub.Service.Dtos.Tweets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakHub.Service.Interfaces.Comments
{
    public interface ICommentService
    {
        public Task<bool> CreateCommentAsync(int id,TweetDto tweetDto);
    }
}
