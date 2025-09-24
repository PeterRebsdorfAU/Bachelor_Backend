using Microsoft.AspNetCore.Mvc;

namespace Bachelor_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScopeController : ControllerBase
    {
        // Dummy systems per bundle
        private static readonly Dictionary<int, List<string>> BundleSystems = new()
        {
            { 1, new List<string> { "Task System", "System 2", "System 3" } },
            { 2, new List<string> { "System X", "System Y" } },
            { 3, new List<string> { "Legacy System" } }
        };

        [HttpGet("{bundleId}")]
        public ActionResult<IEnumerable<string>> GetSystems(int bundleId)
        {
            if (!BundleSystems.TryGetValue(bundleId, out var systems))
                return NotFound(new { message = $"No systems found for bundle {bundleId}" });

            return Ok(systems);
        }

        [HttpPost("{bundleId}")]
        public ActionResult AddSystem(int bundleId, [FromBody] string system)
        {
            if (!BundleSystems.ContainsKey(bundleId))
                return NotFound();

            BundleSystems[bundleId].Add(system);
            return Ok(BundleSystems[bundleId]);
        }

        [HttpDelete("{bundleId}/{systemName}")]
        public ActionResult DeleteSystem(int bundleId, string systemName)
        {
            if (!BundleSystems.ContainsKey(bundleId))
                return NotFound();

            BundleSystems[bundleId].Remove(systemName);
            return Ok(BundleSystems[bundleId]);
        }
    }
}
