using Microsoft.AspNetCore.Mvc;
using Bachelor_Backend.Models;

namespace Bachelor_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScopeController : ControllerBase
    {
        private static readonly List<ReleaseBundle> Bundles = ReleaseBundlesControllerAccessor.Bundles;

        [HttpGet("{bundleId}")]
        public ActionResult<BundleScope> GetScope(int bundleId)
        {
            var bundle = Bundles.FirstOrDefault(b => b.Id == bundleId);
            if (bundle == null) return NotFound();

            return Ok(new BundleScope
            {
                BundleId = bundle.Id,
                BundleName = bundle.Name,
                Systems = bundle.Systems ?? new List<SystemEntry>()
            });
        }

        [HttpPost("{bundleId}")]
        public ActionResult<BundleScope> AddSystem(int bundleId, [FromBody] ScopeModel request)
        {
            var bundle = Bundles.FirstOrDefault(b => b.Id == bundleId);
            if (bundle == null) return NotFound();

            bundle.Systems ??= new List<SystemEntry>();
            bundle.Systems.Add(new SystemEntry { Name = request.Name, Version = request.Version });

            return Ok(new BundleScope
            {
                BundleId = bundle.Id,
                BundleName = bundle.Name,
                Systems = bundle.Systems
            });
        }

        [HttpDelete("{bundleId}/{systemName}")]
        public ActionResult<BundleScope> DeleteSystem(int bundleId, string systemName)
        {
            var bundle = Bundles.FirstOrDefault(b => b.Id == bundleId);
            if (bundle == null) return NotFound();

            var system = bundle.Systems?.FirstOrDefault(s => s.Name == systemName);
            if (system != null)
                bundle.Systems!.Remove(system);

            return Ok(new BundleScope
            {
                BundleId = bundle.Id,
                BundleName = bundle.Name,
                Systems = bundle.Systems ?? new List<SystemEntry>()
            });
        }
    }

    public static class ReleaseBundlesControllerAccessor
    {
        public static List<ReleaseBundle> Bundles { get; } = new()
    {
        new ReleaseBundle {
            Id = 1,
            Name = "Bundle A",
            Status = "PLANNED",
            Systems = new List<SystemEntry> {
                new() { Name = "Task System", Version = "1.0" },
                new() { Name = "System 2", Version = "2.3" },
                new() { Name = "System 3", Version = "0.9-beta" }
            }
        },
        new ReleaseBundle {
            Id = 2,
            Name = "Bundle B",
            Status = "PLANNED",
            Systems = new List<SystemEntry> {
                new() { Name = "System X", Version = "5.4" },
                new() { Name = "System Y", Version = "5.5" }
            }
        },
        new ReleaseBundle {
            Id = 3,
            Name = "Bundle X",
            Status = "RELEASED",
            ReleaseDate = "2025-08-01",
            Systems = new List<SystemEntry> {
                new() { Name = "Legacy System", Version = "1999.1" }
            }
        },
        new ReleaseBundle {
            Id = 4,
            Name = "Bundle Y",
            Status = "RELEASED",
            ReleaseDate = "2025-08-10",
            Systems = new List<SystemEntry>() // tom liste
        }
    };
    }

}
