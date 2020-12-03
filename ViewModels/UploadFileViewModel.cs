using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using WordCounter.ValidationAttributes;

namespace WordCounter.ViewModels
{
    public class UploadFileViewModel
    {
        [Required(ErrorMessage = "Please upload a text file.")]
        [MaxFileSize(20000000)]
        [AllowedExtensions(new string[] { ".txt" })]
        public IFormFile File { get; set; }
    }
}
