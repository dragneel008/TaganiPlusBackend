using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repo.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<ICollection<T>> GetAll();

        Task<T> GetById(object id);

        Task<T> Get(T entity);

        Task Insert(T entity);

        Task Update(T entity);

        Task Delete(T entity);

        Task Remove(T entity);

        Task SaveChanges();
    }
}
