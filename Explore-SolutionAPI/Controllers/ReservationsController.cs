using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Explore.Services.Abstraction;
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
    }
}