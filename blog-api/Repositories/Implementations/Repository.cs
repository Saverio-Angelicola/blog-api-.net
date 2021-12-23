using blog_api.DbContexts;
using blog_api.Models.Interfaces;
using blog_api.Repositories.Interfaces;

namespace blog_api.Repositories.Implementations
{
    public abstract class Repository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : IBlogContext
    {
        private readonly TContext _context;

        public Repository(TContext context)
        {
            _context = context;
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public List<TEntity> FindAll()
        {
            return _context.Set<TEntity>().ToList();
        }
        public TEntity FindById(int id)
        {
            TEntity entity = _context.Set<TEntity>().Where(a => a.Id == id).First();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
