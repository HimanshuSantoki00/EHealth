using System.Linq;
using System.Threading.Tasks;

namespace EH.Entities.Repository
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> GetAll();

        T GetById(int id);

        T Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task<T> GetByIdAsync(int id);

        Task<T> CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
