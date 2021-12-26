using blog_api.Models;
using blog_api.Repositories.Interfaces;
using blog_api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace blog_api.Services.Implementations.Users
{
    public class UserPasswordService : IUserPasswordService
    {
        private readonly IPasswordHasher<User> passwordHasher;
        private readonly IUserRepository userRepository;

        public UserPasswordService(IPasswordHasher<User> passwordHasher, IUserRepository userRepository)
        {
            this.passwordHasher = passwordHasher;
            thid.userRepository = userRepository;
        }

        public string HashPassword(User user)
        {
            return passwordHasher.HashPassword(user, user.Password);
        }

        public bool PasswordVerify(User user, string password)
        {
            PasswordVerificationResult passwordCorrect = PasswordVerificationResult.Success;
            return passwordHasher.VerifyHashedPassword(user, user.Password, password) == passwordCorrect;
        }

        public async Task UpdatePassword(User user, string password, string newPassword)
        {
            if (PasswordVerify(user, password) && password != newPassword)
            {
                user.Password = newPassword;
                string hashNewPassword = HashPassword(user);
                user.Password = hashNewPassword;
                await userRepository.Update(user);
            }
            else
            {
                throw new Exception("Bad password!");
            }
        }
    }
}
