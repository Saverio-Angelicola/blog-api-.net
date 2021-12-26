using blog_api.Dtos.Tokens;
using blog_api.Dtos.Users;
using blog_api.Models;
using blog_api.Services.Interfaces;
using blog_api.Services.Interfaces.Auth;
using blog_api.Services.Interfaces.Tokens;
using blog_api.Services.Interfaces.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blog_api.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly IUserService userService;
        private readonly ILogger<AuthController> _logger;
        private readonly ITokenService tokenService;
        private readonly IUserPasswordService passwordService;
        private readonly IUserInfosUpdatorService userInfosUpdatorService;

        public AuthController
            (
            IAuthService authService, IUserService userService, ILogger<AuthController> logger,
            ITokenService tokenService, IUserPasswordService passwordService,
            IUserInfosUpdatorService userInfosUpdatorService
            )
        {
            this.authService = authService;
            this.userService = userService;
            _logger = logger;
            this.tokenService = tokenService;
            this.passwordService = passwordService;
            this.userInfosUpdatorService = userInfosUpdatorService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(CreateUserDto user)
        {
            try
            {
                User createdUser = await userService.Create(user);
                _logger.LogInformation("Successful registration.");

                return Ok(createdUser);
            }
            catch (Exception)
            {
                _logger.LogError("Registratrion failed.");

                return BadRequest();
            }
        }

        [HttpPost("login")]
        public ActionResult<TokenDto> Login(LoginUserDto user)
        {
            try
            {
                TokenDto jwt = authService.Login(user);
                _logger.LogInformation("successful login.");

                return Ok(jwt);
            }
            catch (Exception)
            {
                _logger.LogError("failed to connect.");

                return BadRequest();
            }

        }

        [HttpGet("get-profile"), Authorize]
        public ActionResult<User> GetProfile()
        {
            try
            {
                string email = tokenService.GetJwtTokenFromAuthorizationHeader(HttpContext).Payload.Claims.ElementAt(0).Value;
                User? user = userService.GetUserByEmail(email);

                if (user == null)
                {
                    return BadRequest("Error : User not found !");
                }

                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("update-password"), Authorize]
        public async Task<ActionResult> UpdatePassword(UpdateUserPasswordDto passwordDto)
        {
            try
            {
                string email = tokenService.GetJwtTokenFromAuthorizationHeader(HttpContext).Payload.Claims.ElementAt(0).Value;
                User? user = userService.GetUserByEmail(email);
                if (user == null)
                {
                    return BadRequest("Error : User not found !");
                }
                await passwordService.UpdatePassword(user, passwordDto.CurrentPassword, passwordDto.NewPassword);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost("update-infos"), Authorize]
        public async Task<ActionResult> UpdateUserInfos(UpdateUserInfosDto userInfosDto)
        {
            try
            {
                string email = tokenService.GetJwtTokenFromAuthorizationHeader(HttpContext).Payload.Claims.ElementAt(0).Value;
                User? user = userService.GetUserByEmail(email);
                if (user == null)
                {
                    return BadRequest("Error : User not found !");
                }

                await userInfosUpdatorService.UpdateInfos(user, userInfosDto);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
