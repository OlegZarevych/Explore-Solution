using Explore.DataAccess.Abstraction.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Explore.DataAccess.Abstraction
{
    public interface IReservationRepository : IRepository<ReservationEntity>
    {
        Task<IEnumerable<ReservationEntity>> GetReservationByTourNameAsync(string tourName);
    }
}