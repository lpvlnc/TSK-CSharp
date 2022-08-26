using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TSK.API.Models;

namespace TSK.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Get")]
        public ActionResult<string> Get()
        {
            return Ok("Ok!");
        }

        [HttpGet]
        [Route("GetSecurity")]
        [Authorize]
        public ActionResult<string> GetSecurity()
        {
            return Ok("Ok!");
        }
    }
}