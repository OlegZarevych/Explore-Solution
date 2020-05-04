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

            int id = await tourService.AddTourAsync(tour);

            return Ok(id);
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
            await tourService.UpdateTourByIdAsync(id, tour);
            return Ok();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await tourService.RemoveTourByIdAsync(id);
            return Ok();
        }
    }
}