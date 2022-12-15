using FinalProjectCSharpTrybe.Context;
using FinalProjectCSharpTrybe.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProjectCSharpTrybe.Services;

namespace FinalProjectCSharpTrybe.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IContext _context;
        public UserRepository(IContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserById(int userId)
        {
            User user = await _context.Users.FirstOrDefaultAsync((user) => user.Id.Equals(userId));

            user.Password = String.Empty;

            return user;
        }

        public async Task<IEnumerable<User>> GetUsersByName(string name)
        {
            var users = await _context.Users.Where((user) => user.Name.Contains(name)).ToListAsync();

            foreach (var user in users)
            {
                user.Password = String.Empty;
            }

            return users;
        }

        public async Task<User> Authenticate(string email, string password)
        {
            bool verified = false;
            
            User user = await _context.Users.Where((user) => user.Email == email).FirstAsync();

            verified = new PasswordHash().VerifyPassword(user, user.Password!, password);

            user.Password = String.Empty;

            if (verified) return user;

            return null;
        }

        public async Task<int> SetUser(User user)
        {

            user.Password = new PasswordHash().GeneratePassword(user);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            user.Password = String.Empty;

            return user.Id;
        }

        public Task<int> UpdateUser(User user)
        {
            var encryptedPassword = new PasswordHasher<User>().HashPassword(user, user.Password);
            user.Password = encryptedPassword;

            _context.Users.Update(user);
            return _context.SaveChangesAsync();
        }
        public async Task<int> DeleteUser(int userId)
        {
            try
            {
                _context.Users.Remove(new User() { Id = userId });
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (!_context.Users.Any(i => i.Id == userId))
                {
                    return 0;
                }
                else
                {
                    throw ex;
                }
            }
        }
    }
}

