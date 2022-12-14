using FinalProjectCSharpTrybe.Models;

namespace FinalProjectCSharpTrybe.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int userId);
        Task<IEnumerable<User>> GetUsersByName(string name);
        Task<User> Authenticate(string email, string password);
        Task<int> SetUser(User user);
        Task<int> DeleteUser(int userId);
        Task<int> UpdateUser(User user);
    }
}

