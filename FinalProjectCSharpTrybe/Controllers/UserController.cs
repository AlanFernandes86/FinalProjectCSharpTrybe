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

        [HttpGet("{user}", Name = "GetUserByIdOrName")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsersByName(string user)
        {
            int id;

            if (int.TryParse(user, out id))
            {
                var res = await _repository.GetUserById(id);
                return Ok(res);
            }

            var result = await _repository.GetUsersByName(user);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> SetUser([FromBody] User user)
        {
            var result = _repository.SetUser(user);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateUser([FromBody] User user)
        {
            var result = _repository.UpdateUser(user);
            return Ok(result);
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult<int>> DeleteUser(int userId)
        {
            var result = await _repository.DeleteUser(userId);
            return Ok(result);
        }
    }
}