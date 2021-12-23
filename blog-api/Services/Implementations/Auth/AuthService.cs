using blog_api.Dtos.Tokens;
using blog_api.Dtos.Users;
using blog_api.Models;
using blog_api.Services.Interfaces;
using blog_api.Services.Interfaces.Auth;
using blog_api.Services.Interfaces.Tokens;
using blog_api.Services.Interfaces.Users;

namespace blog_api.Services.Implementations.Auth
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly IUserPasswordService _passwordService;

        public AuthService(ITokenService tokenService, IUserService userService, IUserPasswordService passwordService)
        {
            _tokenService = tokenService;
            _userService = userService;
            _passwordService = passwordService;
        }

        public TokenDto Login(LoginUserDto loginUser)
        {
            User? user = _userService.GetUserByEmail(loginUser.Email);

            if (user != null && _passwordService.PasswordVerify(user, loginUser.Password))
            {
                return _tokenService.CreateJwtToken(user);
            }
            else
            {
                throw new Exception("Unauthorized");
            }
        }
    }
}
