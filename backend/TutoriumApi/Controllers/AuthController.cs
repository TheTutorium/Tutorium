using System.Threading.Tasks;
using tutorium.Dtos.User;
using tutorium.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tutorium.Services.AuthService;
using tutorium.Utils;

namespace tutorium.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDto request)
        {
            ServiceResponse<int> response = await _authService.Register(request);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto request)
        {
            ServiceResponse<GetUserDto> response = await _authService.Login(request);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }


        // [Authorize]
        [HttpGet("Check")]
        // authorize for tutors
        [Authorize(Roles="Tutor")]
        public async Task<IActionResult> Check()
        {
            // console log hello world
            Console.WriteLine("Hello World");
            ServiceResponse<GetUserDto> response = await _authService.check();
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [Authorize]
        [HttpGet("IdOfUser")]
        public async Task<IActionResult> IdOfUser( string email )
        {
            ServiceResponse<int> response = await _authService.IdOfUser(email);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}