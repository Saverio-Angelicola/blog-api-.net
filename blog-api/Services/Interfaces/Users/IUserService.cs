using blog_api.Dtos.Users;
using blog_api.Models;

namespace blog_api.Services.Interfaces.Users
{
    public interface IUserService
    {
        Task<User> Create(CreateUserDto user);
        User? GetUserByEmail(string email);
        User GetUserById(int id);
    }
}
