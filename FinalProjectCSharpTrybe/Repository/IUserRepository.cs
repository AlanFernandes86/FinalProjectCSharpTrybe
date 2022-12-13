using FinalProjectCSharpTrybe.Models;

namespace FinalProjectCSharpTrybe.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int userId);

        Task<IEnumerable<User>> GetUsersByName(string name);

        int SetUser(User user);
        int DeleteUser(User user);
        int UpdateUser(User user);
    }
}

