using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using tutorium.Dtos.UserDto;
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

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MessageObject), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetUserDto>> CheckUser()
        {
            return CreatedAtAction(null, await _authService.CheckUser());
        }

        [HttpGet("id")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MessageObject), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> GetUserId(string email)  // TODO: Is this necessary?
        {
            return Ok(await _authService.GetUserId(email));
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MessageObject), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetUserDto>> Login(LoginUserDto request)
        {
            return Ok(await _authService.Login(request));
        }


        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(MessageObject), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> Register(SignupUserDto request)
        {
            return CreatedAtAction(null, await _authService.Register(request));
        }
    }
}
