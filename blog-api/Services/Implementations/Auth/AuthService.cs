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
        private readonly ITokenService tokenService;
        private readonly IUserService userService;
        private readonly IUserPasswordService passwordService;

        public AuthService(ITokenService tokenService, IUserService userService, IUserPasswordService passwordService)
        {
            this.tokenService = tokenService;
            this.userService = userService;
            this.passwordService = passwordService;
        }

        public TokenDto Login(LoginUserDto loginUser)
        {
            User? user = this.userService.GetUserByEmail(loginUser.Email);

            if (user != null && this.passwordService.PasswordVerify(user, loginUser.Password))
                return this.tokenService.CreateJwtToken(user);
            
            throw new Exception("Unauthorized");
        }
    }
}
