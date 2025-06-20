using finance_api.Dtos.UserDtos;
using finance_api.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace finance_api.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDto dto)
        {
            var result = await _userService.RegisterAsync(dto);
            return result ? Ok("Usuario registrado") : BadRequest("Usuario ya existe");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto dto)
        {
            var token = await _userService.LoginAsync(dto);
            return token == null ? Unauthorized() : Ok(new AuthResponseDto { Token = token });
        }
    }
}
