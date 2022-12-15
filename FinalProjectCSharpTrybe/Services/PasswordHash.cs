using FinalProjectCSharpTrybe.Models;
using Microsoft.AspNetCore.Identity;

namespace FinalProjectCSharpTrybe.Services
{
    public class PasswordHash
    {
        private readonly PasswordHasher<User> Hasher;
        public PasswordHash() 
        {
            Hasher = new PasswordHasher<User>();
        }
        public string GeneratePassword(User user)
        {
            return Hasher.HashPassword(user, user.Password);
        }

        public bool VerifyPassword(User user, string hashedPassword, string password)
        {
            bool verified = false;
            var result = Hasher.VerifyHashedPassword(user, hashedPassword, password);
            if (result == PasswordVerificationResult.Success) verified = true;
            else if (result == PasswordVerificationResult.SuccessRehashNeeded) verified = true;
            else if (result == PasswordVerificationResult.Failed) verified = false;

            return verified;
        }
    }
}
