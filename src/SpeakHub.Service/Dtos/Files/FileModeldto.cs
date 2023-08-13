using Microsoft.AspNetCore.Http;
using RegistanFerghanaLC.Service.Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakHub.Service.Dtos.Files
{
    public class FileModeldto
    {
        [AllowedFiles(new string[] { ".xlsx" })]
        [Required]
        public IFormFile? File { get; set; }
    }
}
