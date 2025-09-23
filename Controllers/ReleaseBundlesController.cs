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

        // POST: api/ReleaseBundles
        [HttpPost]
        public ActionResult<ReleaseBundle> Create([FromBody] ReleaseBundle newBundle)
        {
            Console.WriteLine("🔹 New bundle received:");
            Console.WriteLine($"Name: {newBundle.Name}");
            Console.WriteLine($"ReleaseDate: {newBundle.ReleaseDate}");
            Console.WriteLine($"Customers: {string.Join(", ", newBundle.Customers ?? new List<string>())}");
            Console.WriteLine($"Systems: {string.Join(", ", newBundle.Systems ?? new List<string>())}");

            if (string.IsNullOrWhiteSpace(newBundle.Name))
            {
                return BadRequest("Bundle name is required.");
            }

            newBundle.Id = Bundles.Any() ? Bundles.Max(b => b.Id) + 1 : 1;
            newBundle.Status = "PLANNED";

            // fallback hvis null
            newBundle.Customers ??= new List<string>();
            newBundle.Systems ??= new List<string>();

            Bundles.Add(newBundle);

            return CreatedAtAction(nameof(Get), new { id = newBundle.Id }, newBundle);
        }

    }
}
