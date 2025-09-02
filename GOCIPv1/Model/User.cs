using System;
using System.ComponentModel.DataAnnotations;

namespace GOCIPv1.Model
{
    public class User
    {
        [Key]
        public required Guid UserId { get; set; }
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
        public string? ProfilePictureUrl { get; set; }
        [MaxLength(50)]
        public string? UserName { get; set; }
        public int? Age { get; set; }
        [MaxLength(10)]
        public string? Gender { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
