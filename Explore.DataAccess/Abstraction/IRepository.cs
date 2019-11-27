using System.Collections.Generic;
using System.Threading.Tasks;

namespace Explore.DataAccess.Abstraction
{
    public interface IRepository<T> where T : class
    {
        void Add<T>(T item);

        Task<Task> AddAsync<T>(T item);

        IEnumerable<T> GetAll();

        T FindById(int id);

        void Remove(int id);

        Task<Task> RemoveAsync(int id);

        void Update<T>(T item);

        Task<Task> UpdateAsync<T>(T item);
    }
}