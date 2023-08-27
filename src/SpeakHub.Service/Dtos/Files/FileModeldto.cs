using Microsoft.AspNetCore.Http;
using SpeakHub.Service.Common.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SpeakHub.Service.Dtos.Files
{
    public class FileModeldto
    {
        [AllowedFiles(new string[] { ".xlsx" })]
        [Required]
        public IFormFile? File { get; set; }
    }
}
