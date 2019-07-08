using ExploreSolution.DTO;
using ExploreSolution.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExploreSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticateService authService;
        public AuthenticationController(IAuthenticateService authService)
        {
            this.authService = authService;
        }

        [AllowAnonymous]
        [HttpPost, Route("request")]
        public ActionResult RequestToken([FromBody] TokenRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string token;
            if (authService.IsAuthenticated(request, out token))
            {
                return Ok(token);
            }

            return BadRequest("Invalid Request");
        }
    }
}