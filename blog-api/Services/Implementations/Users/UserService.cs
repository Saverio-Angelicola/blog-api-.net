using blog_api.Dtos.Users;
using blog_api.Models;
using blog_api.Repositories.Interfaces;
using blog_api.Services.Interfaces;
using blog_api.Services.Interfaces.Users;

namespace blog_api.Services.Implementations.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserPasswordService _passwordService;

        public UserService(IUserRepository repository, IUserPasswordService passwordService)
        {
            this._userRepository = repository;
            this._passwordService = passwordService;
        }

        public async Task<User> Create(CreateUserDto user)
        {
            User newUser = new(user.FirstName, user.LastName, user.Email, user.Password, true);
            newUser.Password = _passwordService.HashPassword(newUser);
            return await _userRepository.Create(newUser);
        }

        public User? GetUserByEmail(string email)
        {
            return _userRepository.FindByEmail(email);
        }

        public User GetUserById(int id)
        {
            return _userRepository.FindById(id);
        }
    }
}
