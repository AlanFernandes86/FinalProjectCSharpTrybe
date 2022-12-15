using Microsoft.EntityFrameworkCore;
using FinalProjectCSharpTrybe.Context;
using FinalProjectCSharpTrybe.Models;
using FinalProjectCSharpTrybe.Controllers;

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
        public async Task<int> SetPost(RequestPost requestPost)
        {
            Post post = new Post
            {
                Title = requestPost.Title,
                Message = requestPost.Message,
                ImageURL = requestPost.ImageURL,
                UserId = requestPost.UserId,
                UpdatedAt = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow,
            };
            
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return post.Id;
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
            var post = new Post() { Id = id, Message = message, UpdatedAt = DateTime.UtcNow };

            _context.Posts.Attach(post);
            _context.Posts.Entry(post).Property(x => x.Message).IsModified = true;
            return await _context.SaveChangesAsync();
        }
    }

}
