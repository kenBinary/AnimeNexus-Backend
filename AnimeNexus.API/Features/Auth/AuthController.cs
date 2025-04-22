using backend.AnimeNexus.API.Features.Auth.Interfaces;
using backend.AnimeNexus.API.Features.Auth.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnimeNexus.API.Features.Auth
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginRequest loginRequest)
        {
            var result = await _authService.AuthenticateUserAsync(loginRequest.UserName, loginRequest.Password);

            if (!result.Success)
            {
                return Unauthorized(result.ErrorMessage);
            }

            return Ok(result.Token);
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegisterUserResponse>> RegisterUser([FromBody] RegisterRequest registerRequest)
        {
            var result = await _authService.AddNewUserAsync(registerRequest.UserName, registerRequest.Password);

            if (!result.Success)
            {
                return BadRequest(result.ErrorMessage);
            }

            var response = new RegisterUserResponse
            {
                UserName = registerRequest.UserName
            };

            return Created("", response);
        }

    }
}
