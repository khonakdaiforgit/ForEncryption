using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ForEncryption.Models
{
    public class DecryptionViewModel
    {
        [Required(ErrorMessage = "EncryptedText cannot be empty.")]
        [StringLength(2000, MinimumLength = 1, ErrorMessage = "EncryptedText must be between 1 and 2000 characters.")]
        public string EncryptedText { get; set; }
        [Required(ErrorMessage = "EncryptionKey cannot be empty.")]
        public string EncryptionKey { get; set; }
        public string? DecryptedText { get; set; }
    }
}
