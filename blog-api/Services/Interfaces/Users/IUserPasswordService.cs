using blog_api.Models;

namespace blog_api.Services.Interfaces
{
    public interface IUserPasswordService
    {
        string HashPassword(User user);
        bool PasswordVerify(User user, string password);
        Task UpdatePassword(User user, string password, string newPassword);
    }
}
