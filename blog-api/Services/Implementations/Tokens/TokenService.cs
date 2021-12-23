using blog_api.Dtos.Tokens;
using blog_api.Models;
using blog_api.Services.Interfaces.Tokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace blog_api.Services.Implementations.Tokens
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public TokenDto CreateJwtToken(User user)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Admin ? "Admin" : "User")
            };

            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken token = new(claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: credentials);

            string jwt = new JwtSecurityTokenHandler().WriteToken(token);
            TokenDto tokenDto = new(jwt);

            return tokenDto;
        }

        public JwtSecurityToken GetJwtTokenFromAuthorizationHeader(HttpContext context)
        {
            string bearerToken = context.Request.Headers.Authorization;
            string token = bearerToken.Remove(0, 7);
            JwtSecurityToken jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
            return jwt;
        }
    }
}
