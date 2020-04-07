using System.Linq;
using System.Threading.Tasks;
using Explore.Dto.Abstraction.DTO;
using Explore.Services.Abstraction;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExploreSolution.API.OData
{
    [Route("api/odata/[controller]")]
    public class ReservationController : ODataController
    {
        private readonly IReservationService reservationService;
        public ReservationController(IReservationService reservationService)
        {
            this.reservationService = reservationService;
        }

        [Authorize]
        [HttpGet]
        [EnableQuery]
        public async Task<IQueryable<Reservation>> GetReservations()
        {
            var result = await reservationService.GetAllReservationsAsync();

            return result.AsQueryable();
        }
    }
}