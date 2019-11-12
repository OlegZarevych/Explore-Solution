using System.Collections.Generic;

namespace Explore.DataAccess.Abstraction
{
    public interface IRepository<T> where T : class
    {
        void Add<T>(T item);
        IEnumerable<T> GetAll();
        T FindById(int id);
        void Remove(int id);
        void Update<T>(T item);
    }
}