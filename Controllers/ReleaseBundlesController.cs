using Microsoft.AspNetCore.Mvc;
using Bachelor_Backend.Models;

namespace Bachelor_Backend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ReleaseBundlesController : ControllerBase
    {
        // Dummy data
        private static readonly List<ReleaseBundle> Bundles = new()
    {
        new ReleaseBundle { Id = 1, Name = "Bundle A", Status = "PLANNED" },
        new ReleaseBundle { Id = 2, Name = "Bundle B", Status = "PLANNED" },
        new ReleaseBundle { Id = 3, Name = "Bundle X", Status = "RELEASED", ReleaseDate = "2025-08-01" },
        new ReleaseBundle { Id = 4, Name = "Bundle Y", Status = "RELEASED", ReleaseDate = "2025-08-10" }
    };

        [HttpGet]
        public ActionResult<IEnumerable<ReleaseBundle>> Get()
        {
            return Ok(Bundles);
        }
    }
}