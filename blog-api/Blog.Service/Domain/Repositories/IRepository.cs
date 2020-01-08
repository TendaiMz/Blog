using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Service.Domain.Repositories
{
    public interface IRepository<T>
    {
        Task<T> Get(int Id);
        Task<IEnumerable<T>> GetAll();
        Task Save(T entity);
        Task Update(T entity);
        Task Delete(int Id);

    }
}
