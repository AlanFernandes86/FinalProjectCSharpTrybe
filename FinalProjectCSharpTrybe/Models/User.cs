using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectCSharpTrybe.Models
{
    [Table("Users")]
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
        [StringLength(50)]
        public string? Password { get; set; }

        public ICollection<Post>? Posts { get; set; }
    }
}

