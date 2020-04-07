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
        public async Task<IQueryable<Reservation>> Get()
        {
            var result = await reservationService.GetAllReservationsAsync();

            return result.AsQueryable();
        }

        //[Authorize]
        //[HttpDelete]
        //[EnableQuery]
        //public async Task<IQueryable<Reservation>> Delete([FromODataUri]string key)
        //{
        //    var result = await reservationService.GetAllReservationsAsync();

        //    return result.Where(r => r.Id == Convert.ToInt32(key)).AsQueryable();
        //}

        //[Authorize]
        //[HttpPatch]
        //[EnableQuery]
        //public async Task<Reservation> PatchReservations(int key, Delta<Reservation> patch)
        //{
        //    var result = await reservationService.GetAllReservationsAsync();
        //    var reservation = result.AsQueryable().FirstOrDefault(r => r.Id == key);
        //    patch.Patch(reservation);

        //    return reservation;
        //}
    }
}