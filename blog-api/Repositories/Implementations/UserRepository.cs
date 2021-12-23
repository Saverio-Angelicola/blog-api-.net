using blog_api.DbContexts;
using blog_api.Models;
using blog_api.Repositories.Interfaces;

namespace blog_api.Repositories.Implementations
{
    public class UserRepository : Repository<User, IBlogContext>, IUserRepository
    {
        private readonly IBlogContext _context;
        public UserRepository(IBlogContext context) : base(context)
        {
            _context = context;
        }

        public User? FindByEmail(string email)
        {
            return _context.Set<User>().Where(u => u.Email == email).FirstOrDefault();
        }
    }
}
