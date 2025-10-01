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
            new ReleaseBundle { Id = 1, Name = "Bundle A", Status = "PLANNED", Systems = new List<SystemEntry> {
                new() { Name = "Task System" },
                new() { Name = "System 2" },
                new() { Name = "System 3" }
            }},
            new ReleaseBundle { Id = 2, Name = "Bundle B", Status = "PLANNED", Systems = new List<SystemEntry> {
                new() { Name = "System X" },
                new() { Name = "System Y" }
            }},
            new ReleaseBundle { Id = 3, Name = "Bundle X", Status = "RELEASED", ReleaseDate = "2025-08-01", Systems = new List<SystemEntry> {
                new() { Name = "Legacy System" }
            }},
            new ReleaseBundle { Id = 4, Name = "Bundle Y", Status = "RELEASED", ReleaseDate = "2025-08-10", Systems = new List<SystemEntry>() }
        };

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

        // Create Release bundle
        [HttpPost]
        public ActionResult<ReleaseBundle> Create([FromBody] ReleaseBundle newBundle)
        {
            // Log som JSON i konsollen
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

        // Release existing bundle
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
