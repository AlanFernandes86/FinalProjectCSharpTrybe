using FinalProjectCSharpTrybe.Context;
using FinalProjectCSharpTrybe.Models;
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

        public int SetUser(User user)
        {
            _context.Users.Add(user);
            return _context.SaveChanges();
        }

        public int UpdateUser(User user)
        {
            _context.Users.Update(user);
            return _context.SaveChanges();
        }
        public int DeleteUser(User user)
        {
            _context.Users.Remove(user);
            return _context.SaveChanges();
        }
    }
}

