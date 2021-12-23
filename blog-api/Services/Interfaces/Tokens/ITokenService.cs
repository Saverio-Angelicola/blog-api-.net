using blog_api.Dtos.Tokens;
using blog_api.Models;
using System.IdentityModel.Tokens.Jwt;

namespace blog_api.Services.Interfaces.Tokens
{
    public interface ITokenService
    {
        TokenDto CreateJwtToken(User user);
        JwtSecurityToken GetJwtTokenFromAuthorizationHeader(HttpContext context);
    }
}
