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
            return await _context.Posts.Where((post) => post.UserId == userId).OrderByDescending(p => p.UpdatedAt).FirstAsync();
        }
        public int SetPost(Post post)
        {
            _context.Posts.Add(post);
            return _context.SaveChanges();
        }

        public int DeletePost(Post post)
        {
            _context.Posts.Remove(post);
            return _context.SaveChanges();
        }

        public int UpdatePostMessage(int id, string message)
        {
            return _context.Posts.Where(x => x.Id == id).ExecuteUpdate((y) => y.SetProperty((post) => post.Message, message));

            //var post = new Post() { Id = id, Message = message };

            //_context.Posts.Attach(post);
            //_context.Posts.Entry(post).Property(x => x.Message).IsModified = true;
            //return _context.SaveChanges();
        }
    }

}
