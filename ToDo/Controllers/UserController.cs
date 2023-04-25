using Microsoft.AspNetCore.Authorization;
using ToDo.Services;
using Microsoft.AspNetCore.Mvc;
using ToDo.Models.Dtos;
using ToDo.Services.Interface;

namespace ToDo.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult RegisterUser([FromBody] RegisterUserDto dto)
        {
            _service.RegisterUser(dto);
            return Ok();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult GenerateLoginToken([FromBody] LoginDto dto)
        {
            string token = _service.GenerateLoginToken(dto);
            return Ok(token);
        }

        [HttpGet("get-users")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetUsers()
        {
            var users = _service.GetUsers();
            return Ok(users);
        }
    }
}