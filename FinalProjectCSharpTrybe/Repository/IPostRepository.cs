using FinalProjectCSharpTrybe.Models;

namespace FinalProjectCSharpTrybe.Repository
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllPosts(int userId);

        Task<Post> GetLastPost(int userId);

        Task<int> SetPost(Post post);
        Task<int> DeletePost(int id);
        Task<int> UpdatePostMessage(int id, string message);
    }
}
