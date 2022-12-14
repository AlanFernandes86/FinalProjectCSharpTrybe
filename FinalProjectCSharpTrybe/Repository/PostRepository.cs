using Microsoft.EntityFrameworkCore;
using FinalProjectCSharpTrybe.Context;
using FinalProjectCSharpTrybe.Models;

namespace FinalProjectCSharpTrybe.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly IContext _context;
        public PostRepository(IContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Post>> GetAllPosts(int userId)
        {
            return await _context.Posts.Where((post) => post.UserId == userId).ToListAsync();
        }

        public async Task<Post> GetLastPost(int userId)
        {
            return await _context.Posts.Where((post) => post.UserId == userId).OrderByDescending(p => p.Id).FirstAsync();
        }
        public async Task<int> SetPost(Post post)
        {
            _context.Posts.Add(post);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeletePost(int postId)
        {
            try
            {
                _context.Posts.Remove(new Post() { Id = postId });
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (!_context.Posts.Any(i => i.Id == postId))
                {
                    return 0;
                }
                else
                {
                    throw ex;
                }
            }
        }

        public async Task<int> UpdatePostMessage(int id, string message)
        {
            var post = new Post() { Id = id, Message = message };

            _context.Posts.Attach(post);
            _context.Posts.Entry(post).Property(x => x.Message).IsModified = true;
            return await _context.SaveChangesAsync();
        }
    }

}
