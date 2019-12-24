using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Explore.Dto.Abstraction.DTO;
using Explore.Services.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExploreSolution.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService reservationService; 
        public ReservationsController(IReservationService reservationService)
        {
            this.reservationService = reservationService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllReservations()
        {
            return Ok(await reservationService.GetAllReservationsAsync());
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddReservation([FromBody]ReservationDto reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await reservationService.AddReservationAsync(reservation);
            return Ok();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllReservationByTourName([FromQuery]string tourName)
        {
            return Ok(await reservationService.GetAllReservationsByTourNameAsync(tourName));
        }
    }
}