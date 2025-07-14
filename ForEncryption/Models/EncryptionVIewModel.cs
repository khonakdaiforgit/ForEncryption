using System.ComponentModel.DataAnnotations;

namespace ForEncryption.Models
{
    public class EncryptionVIewModel
    {
        [Required(ErrorMessage = "Message cannot be empty.")]
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "Message must be between 1 and 1000 characters.")]
        public string PlainText { get; set; }
        [Required(ErrorMessage = "EncryptionKey cannot be empty.")]
        public string EncryptionKey { get; set; }
        public string? EncryptedText { get; set; }
    }
}
