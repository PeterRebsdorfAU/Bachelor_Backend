using Microsoft.AspNetCore.Mvc;
using Bachelor_Backend.Models;
using Bachelor_Backend.Data;

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
}
