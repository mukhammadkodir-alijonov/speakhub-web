using SpeakHub.Service.Common.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SpeakHub.Service.Dtos.Accounts
{
    public class SendToEmailDto
    {
        [Required(ErrorMessage = "Email is required!"), EmailAttribute]
        public string Email { get; set; } = string.Empty;
    }
}
