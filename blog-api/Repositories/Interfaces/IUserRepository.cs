using blog_api.Models;

namespace blog_api.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User? FindByEmail(string email);
    }
}
