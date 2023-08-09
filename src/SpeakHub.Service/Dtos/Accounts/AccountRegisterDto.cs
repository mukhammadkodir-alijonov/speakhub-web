using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakHub.Service.Dtos.Accounts
{
    public class AccountRegisterDto : AccountLoginDto
    {
        public string Email { get; set; } = String.Empty;

        [Required(ErrorMessage = "Enter a name!")]
        public string FirstName { get; set; } = String.Empty;

        [Required(ErrorMessage = "Enter a surname!")]
        public string LastName { get; set; } = String.Empty;
        public DateTime BirthDate { get; set; }
    }
}
