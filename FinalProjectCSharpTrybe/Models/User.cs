using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace FinalProjectCSharpTrybe.Models
{
    [Table("Users")]
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public string? Module { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        [StringLength(500)]
        public string? Password { get; set; }

        public ICollection<Post>? Posts { get; set; }
    }
}

