using System;
using System.Threading.Tasks;

namespace Explore.DataAccess.Abstraction
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();

        int Commit();

        ITourRepository TourRepository { get; set; }

        IReservationRepository ReservationRepository { get; set; }
    }
}