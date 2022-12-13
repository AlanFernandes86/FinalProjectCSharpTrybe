using FinalProjectCSharpTrybe.Models;
using FinalProjectCSharpTrybe.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectCSharpTrybe.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        public UserController(IUserRepository userRepository)
        {
            _repository = userRepository;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<Post>>> GetUserById(int userId)
        {
            var result = await _repository.GetUserById(userId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> SetUser([FromBody] User user)
        {
            var result = _repository.SetUser(user);
            return Ok(result);
        }
    }
}