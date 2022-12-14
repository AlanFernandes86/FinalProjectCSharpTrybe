using System.ComponentModel.DataAnnotations;

namespace FinalProjectCSharpTrybe.DTO
{
    public class UserDTO
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Module { get; set; }

        public int Status { get; set; }

        public string? Password { get; set; }
    }
}
