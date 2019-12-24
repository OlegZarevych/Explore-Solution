using Explore.DataAccess.Abstraction.Entities;
using Explore.Dto.Abstraction.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Explore.Services.Abstraction
{
    public interface IReservationService
    {
        Task<IEnumerable<Reservation>> GetAllReservationsAsync();

        Task AddReservationAsync(ReservationDto reservation);

        Task<IEnumerable<ReservationEntity>> GetAllReservationsByTourNameAsync(string tourName);
    }
}