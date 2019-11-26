using Explore.Services.Abstraction;
using ExploreSolution.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExploreSolution.API.Controllers
{
    [Route("api/[controller]/[action]")]
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
        public async Task<IActionResult> Add([FromBody] TourDto tour)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tourService.AddTourAsync(tour);

            return Ok();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await tourService.GetAllToursAsync());
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit([FromQuery] int id, [FromBody] TourDto tour)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(tourService.UpdateTourById(id, tour));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            tourService.RemoveTourByIdAsync(id);
            return Ok();
        }
    }
}