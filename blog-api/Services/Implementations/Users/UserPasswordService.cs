using blog_api.Models;
using blog_api.Repositories.Interfaces;
using blog_api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace blog_api.Services.Implementations.Users
{
    public class UserPasswordService : IUserPasswordService
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IUserRepository _userRepository;

        public UserPasswordService(IPasswordHasher<User> passwordHasher, IUserRepository userRepository)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
        }

        public string HashPassword(User user)
        {
            return _passwordHasher.HashPassword(user, user.Password);
        }

        public bool PasswordVerify(User user, string password)
        {
            PasswordVerificationResult passwordCorrect = PasswordVerificationResult.Success;
            return _passwordHasher.VerifyHashedPassword(user, user.Password, password) == passwordCorrect;
        }

        public async Task UpdatePassword(User user, string password, string newPassword)
        {
            if (PasswordVerify(user, password) && password != newPassword)
            {
                user.Password = newPassword;
                string hashNewPassword = HashPassword(user);
                user.Password = hashNewPassword;
                await _userRepository.Update(user);
            }
            else
            {
                throw new Exception("Bad password!");
            }
        }
    }
}
