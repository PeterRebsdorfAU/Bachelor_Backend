using Microsoft.AspNetCore.Mvc;
using Bachelor_Backend.Models;
using Bachelor_Backend.Data;

namespace Bachelor_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReleaseBundlesController : ControllerBase
    {
        private static readonly List<ReleaseBundle> Bundles = ReleaseBundlesControllerAccessor.Bundles;

        [HttpGet]
        public ActionResult<IEnumerable<ReleaseBundle>> Get()
        {
            return Ok(Bundles);
        }

        [HttpGet("{id}")]
        public ActionResult<ReleaseBundle> GetById(int id)
        {
            var bundle = Bundles.FirstOrDefault(b => b.Id == id);
            if (bundle == null) return NotFound();
            return Ok(bundle);
        }

        [HttpPost]
        public ActionResult<ReleaseBundle> Create([FromBody] ReleaseBundle newBundle)
        {
            Console.WriteLine(" Received new bundle:");
            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(newBundle, new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true
            }));

            if (string.IsNullOrWhiteSpace(newBundle.Name))
                return BadRequest("Bundle name is required.");

            newBundle.Id = Bundles.Any() ? Bundles.Max(b => b.Id) + 1 : 1;
            newBundle.Status = "PLANNED";
            newBundle.Customers ??= new List<string>();
            newBundle.Systems ??= new List<SystemEntry>();

            Bundles.Add(newBundle);

            return CreatedAtAction(nameof(GetById), new { id = newBundle.Id }, newBundle);
        }

        [HttpPost("{id}/release")]
        public ActionResult<ReleaseBundle> Release(int id)
        {
            var bundle = Bundles.FirstOrDefault(b => b.Id == id);
            if (bundle == null)
                return NotFound();

            if (bundle.Status == "RELEASED")
                return BadRequest("Bundle is already released.");

            bundle.Status = "RELEASED";
            bundle.ReleaseDate = DateTime.UtcNow.ToString("yyyy-MM-dd");

            return Ok(bundle);
        }
    }
}
