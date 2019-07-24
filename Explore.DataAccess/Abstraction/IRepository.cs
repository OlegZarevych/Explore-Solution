using System.Collections.Generic;

namespace Explore.DataAccess.Abstraction
{
    public interface IRepository<T> where T : class
    {
        void Add<T>(T item);
        IEnumerable<T> GetAll();
        T Find();
        void Remove();
        void Update();
    }
}