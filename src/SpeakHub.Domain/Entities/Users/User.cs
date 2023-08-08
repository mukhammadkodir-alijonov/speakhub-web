using SpeakHub.Domain.Common;
using SpeakHub.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakHub.Domain.Entities.Users
{
    public class User : Human
    {
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Salt { get; set; } = string.Empty;
        public StatusType Status { get; set; } = StatusType.Active;
        public DateTime RegistrationDate { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
