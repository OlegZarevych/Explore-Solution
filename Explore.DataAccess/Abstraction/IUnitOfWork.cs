using System;
using System.Threading.Tasks;

namespace Explore.DataAccess.Abstraction
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();

        ITourRepository TourRepository { get; set; }
    }
}
