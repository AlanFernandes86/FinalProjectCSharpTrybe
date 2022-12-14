using FinalProjectCSharpTrybe.Controllers.Response;
using FinalProjectCSharpTrybe.Enums;
using FinalProjectCSharpTrybe.Models;
using FinalProjectCSharpTrybe.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectCSharpTrybe.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _repository;
        public PostController(IPostRepository postRepository)
        {
            _repository = postRepository;
        }

        [HttpGet("{userId}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Post>>> GetPost(int userId, bool All)
        {

            if (All)
            {
                var result = await _repository.GetAllPosts(userId);
                return Ok(new BaseResponse(ResponseStatus.Success, result));
            }
            else
            {
                var result = await _repository.GetLastPost(userId);
                return Ok(new BaseResponse(ResponseStatus.Success, result));
            }            
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<int>> SetPost([FromBody] Post post)
        {
            var result = await _repository.SetPost(post);
            return Ok(new BaseResponse(ResponseStatus.Success, result));
        }

        [HttpPatch]
        [Authorize]
        public async Task<ActionResult<int>> UpdatePost([FromBody] PostMessage postMessage)
        {
            var result = await _repository.UpdatePostMessage(postMessage.Id, postMessage.Message);
            return Ok(new BaseResponse(ResponseStatus.Success, result));
        }

        [HttpDelete("{postId}")]
        [Authorize]
        public async Task<ActionResult<int>> DeletePost(int postId)
        {
            var result = await _repository.DeletePost(postId);
            return Ok(new BaseResponse(ResponseStatus.Success, result));
        }
    }
}