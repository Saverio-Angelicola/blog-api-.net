using blog_api.Models.Interfaces;

namespace blog_api.Repositories.Interfaces
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<T> Create(T entity);
        Task<T> Delete(T entity);
        List<T> FindAll();
        T FindById(int id);
        Task<T> Update(T entity);

    }
}
