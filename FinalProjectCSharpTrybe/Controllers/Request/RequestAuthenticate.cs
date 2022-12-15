using FinalProjectCSharpTrybe.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace FinalProjectCSharpTrybe.Controllers
{
    public class RequestAuthenticate
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}

