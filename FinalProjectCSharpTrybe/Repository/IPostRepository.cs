using FinalProjectCSharpTrybe.Controllers;
using FinalProjectCSharpTrybe.Models;

namespace FinalProjectCSharpTrybe.Repository
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllPosts(int userId);

        Task<Post> GetLastPost(int userId);

        Task<int> SetPost(RequestPost requestPost);
        Task<int> DeletePost(int id);
        Task<int> UpdatePostMessage(int id, string message);
    }
}
