using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Explore.DataAccess.Abstraction.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExploreSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToursController : ControllerBase
    {


        [Authorize]
        [HttpPost]
        public void Add([FromBody] TourEntity tour)
        {

        }
    }
}