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

        [HttpGet("{userId}", Name="GetLastPost")]
        public async Task<ActionResult<IEnumerable<Post>>> GetLastPost(int userId)
        {
            var result = await _repository.GetLastPost(userId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> SetPost([FromBody] Post post)
        {
            var result = _repository.SetPost(post);
            return Ok(result);
        }
    }
}