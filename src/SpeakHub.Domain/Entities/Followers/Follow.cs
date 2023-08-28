﻿using SpeakHub.Domain.Common;
using SpeakHub.Domain.Entities.Users;

namespace SpeakHub.Domain.Entities.Followers
{
    public class Follow : Auditable
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int FollowerId { get; set; }
        public virtual User Follower { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
