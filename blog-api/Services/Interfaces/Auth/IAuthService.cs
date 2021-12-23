using blog_api.Dtos.Tokens;
using blog_api.Dtos.Users;

namespace blog_api.Services.Interfaces.Auth
{
    public interface IAuthService
    {
        TokenDto Login(LoginUserDto loginUser);
    }
}
