using FinalProjectCSharpTrybe.Context;
using FinalProjectCSharpTrybe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            return await _context.Users.FirstOrDefaultAsync((user) => user.Id.Equals(userId));
        }

        public async Task<IEnumerable<User>> GetUsersByName(string name)
        {
            return await _context.Users.Where((user) => user.Name.Contains(name)).ToListAsync();
        }

        public Task<int> SetUser(User user)
        {
            _context.Users.Add(user);
            return _context.SaveChangesAsync();
        }

        public Task<int> UpdateUser(User user)
        {
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

