using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakHub.Service.ViewModels.LikeViewModels
{
    public class LikeViewModel
    {
        public int LikeCount { get; set; }
        public bool IsLikedByCurrentUser { get; set; }
    }
}
