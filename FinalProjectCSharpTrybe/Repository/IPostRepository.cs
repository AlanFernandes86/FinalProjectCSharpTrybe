using FinalProjectCSharpTrybe.Models;

namespace FinalProjectCSharpTrybe.Repository
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllPosts(int userId);

        Task<Post> GetLastPost(int userId);

        int SetPost(Post post);
        int DeletePost(Post post);
        int UpdatePostMessage(int id, string message);
    }
}
