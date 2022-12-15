using FinalProjectCSharpTrybe.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace FinalProjectCSharpTrybe.Controllers
{
    public class RequestUser
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Module { get; set; }

        public int Status { get; set; }

        public string Password { get; set; }

        public User ToUser() 
        {
            return new User
            {
                Name = Name,
                Email = Email,
                Module = Module,
                Status = Status,
                Password = Password
            };
        }

    }
}

