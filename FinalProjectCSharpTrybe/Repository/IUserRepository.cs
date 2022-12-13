using FinalProjectCSharpTrybe.Models;

namespace FinalProjectCSharpTrybe.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int userId);

        Task<IEnumerable<User>> GetUsersByName(string name);

        int SetUser(User user);
        Task<int> DeleteUser(int userId);
        int UpdateUser(User user);
    }
}

