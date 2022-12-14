using FinalProjectCSharpTrybe.Controllers.Response;
using FinalProjectCSharpTrybe.DTO;
using FinalProjectCSharpTrybe.Enums;
using FinalProjectCSharpTrybe.Models;
using FinalProjectCSharpTrybe.Repository;
using FinalProjectCSharpTrybe.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectCSharpTrybe.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        public UserController(IUserRepository userRepository)
        {
            _repository = userRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<AuthenticateResponse>> Authenticate([FromBody] User user)
        {
            var result = await _repository.Authenticate(user.Email, user.Password);

            if (result != null)
            {
                var token = new TokenGenerator().Generate(result);
                return Ok(new AuthenticateResponse(result, token));
            }

            return Unauthorized("Usuário ou senha inválido.");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<int>> SetUser([FromBody] User user)
        {
            var result = await _repository.SetUser(user);

            if (result != 0)
            {
                user.Id = result;
                var token = new TokenGenerator().Generate(user);
                return Ok(new AuthenticateResponse(user, token));
            }

            return BadRequest("Error ao cadastrar usuário.");
        }

        [HttpGet("{user}", Name = "GetUserByIdOrName")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<User>>> GetUsersByName(string user)
        {
            int id;

            if (int.TryParse(user, out id))
            {
                var res = await _repository.GetUserById(id);
                return Ok(new BaseResponse(ResponseStatus.Success, res));
            }

            var result = await _repository.GetUsersByName(user);
            return Ok(new BaseResponse(ResponseStatus.Success, result));
        }


        [HttpPut]
        [Authorize]
        public async Task<ActionResult<int>> UpdateUser([FromBody] User user)
        {
            var result = await _repository.UpdateUser(user);
            return Ok(new BaseResponse(ResponseStatus.Success, result));
        }

        [HttpDelete("{userId}")]
        [Authorize]
        public async Task<ActionResult<int>> DeleteUser(int userId)
        {
            var result = await _repository.DeleteUser(userId);
            return Ok(new BaseResponse(ResponseStatus.Success, result));
        }
    }
}