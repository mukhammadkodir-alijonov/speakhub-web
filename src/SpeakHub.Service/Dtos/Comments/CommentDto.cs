using SpeakHub.Domain.Common;
using SpeakHub.Service.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakHub.Service.Dtos.Comments
{
    public class CommentDto : Auditable
    {
        [Comment]
        public string CommentText { get; set; } = string.Empty;
    }
}
