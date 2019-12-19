using System.Collections.Generic;
using System.Threading.Tasks;

namespace Explore.DataAccess.Abstraction
{
    public interface IRepository<T> where T : class
    {
        void Add(T item);

        Task AddAsync(T item);

        IEnumerable<T> GetAll();

        Task<IEnumerable<T>> GetAllAsync();

        T FindById(int id);

        void Remove(int id);

        Task RemoveAsync(int id);

        void Update(T item);

        Task UpdateAsync(T item);
    }
}