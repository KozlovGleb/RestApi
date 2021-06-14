using Microsoft.AspNetCore.Mvc;
using RestApi.DataAccess.DTOs;
using RestApi.DataAccess.Request;
using RestApi.Services.Interfaces;
using System.Threading.Tasks;

namespace RestApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" }); 

            return Ok(response);
        }
        [HttpPost("registration")]
        public async Task<IActionResult> UserRegistrationAsync([FromQuery] UserDTO user)
        {
            await _userService.AddUserAsync(user);
            return Ok();//Добавить нормальные ошибки
        }
    }
}
