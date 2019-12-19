using Explore.Dto.Abstraction.DTO;
using Explore.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Explore.Services.Services
{
    public class ReservationService : IReservationService
    {
        public async Task AddReservationAsync(ReservationDto reservation)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Reservation>> GetAllReservationsAsync()
        {
            throw new NotImplementedException();
        }
    }
}