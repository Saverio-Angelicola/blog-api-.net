using blog_api.Dtos.Users;
using blog_api.Models;
using blog_api.Repositories.Interfaces;
using blog_api.Services.Interfaces;
using blog_api.Services.Interfaces.Users;

namespace blog_api.Services.Implementations.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUserPasswordService passwordService;

        public UserService(IUserRepository userRepository, IUserPasswordService passwordService)
        {
            this.userRepository = userRepository;
            this.passwordService = passwordService;
        }

        public async Task<User> Create(CreateUserDto user)
        {
            User newUser = new(user.FirstName, user.LastName, user.Email, user.Password, true);
            newUser.Password = passwordService.HashPassword(newUser);
            return await userRepository.Create(newUser);
        }

        public User? GetUserByEmail(string email)
        {
            return userRepository.FindByEmail(email);
        }

        public User GetUserById(int id)
        {
            return userRepository.FindById(id);
        }
    }
}
