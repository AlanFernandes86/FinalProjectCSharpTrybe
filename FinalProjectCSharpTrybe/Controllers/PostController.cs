using FinalProjectCSharpTrybe.Models;
using FinalProjectCSharpTrybe.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectCSharpTrybe.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _repository;
        public PostController(IPostRepository postRepository)
        {
            _repository = postRepository;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<Post>>> GetPost(int userId, bool All)
        {

            if (All)
            {
                var result = await _repository.GetAllPosts(userId);
                return Ok(result);
            }
            else
            {
                var result = await _repository.GetLastPost(userId);
                return Ok(result);
            }            
        }

        [HttpPost]
        public async Task<ActionResult<int>> SetPost([FromBody] Post post)
        {
            var result = await _repository.SetPost(post);
            return Ok(result);
        }

        [HttpPatch]
        public async Task<ActionResult<int>> UpdatePost([FromBody] int id, string message)
        {
            var result = await _repository.UpdatePostMessage(id, message);
            return Ok(result);
        }

        [HttpDelete("{postId}")]
        public async Task<ActionResult<int>> DeletePost(int postId)
        {
            var result = await _repository.DeletePost(postId);
            return Ok(result);
        }
    }
}