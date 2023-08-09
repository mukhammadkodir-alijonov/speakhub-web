﻿using RegistanFerghanaLC.Service.Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakHub.Service.Dtos.Accounts
{
    public class AccountLoginDto
    {
        [Required(ErrorMessage = "Enter a phone number!")]
        [PhoneNumber]
        public string PhoneNumber { get; set; } = String.Empty;

        [Required(ErrorMessage = "Enter a password!")]
        [StrongPassword]
        public string Password { get; set; } = String.Empty;
    }
}
