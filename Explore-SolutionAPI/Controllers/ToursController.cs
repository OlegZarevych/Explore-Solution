using Explore.Services.Abstraction;
using ExploreSolution.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExploreSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToursController : ControllerBase
    {
        private ITourService tourService;

        public ToursController(ITourService tourService)
        {
            this.tourService = tourService;
        }

        [Authorize]
        [HttpPost]
        [Route("[action]")]
        public ActionResult Add([FromBody] TourDto tour)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tourService.AddTour(tour);

            return Ok();
        }
    }
}