using Microsoft.AspNetCore.Mvc;
using Bachelor_Backend.Models;

namespace Bachelor_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChecklistController : ControllerBase
    {
        // Dummy checklists
        private static readonly Dictionary<int, List<string>> Checklists = new()
        {
            { 1, new List<string> { "Plan created", "QA started", "Deployment pending" } },
            { 2, new List<string> { "Plan created", "In progress" } },
            { 3, new List<string> { "Released", "Documentation uploaded" } },
            { 4, new List<string> { "Released" } }
        };

        // Dummy bundles (samme som i ReleaseBundlesController)
        private static readonly List<ReleaseBundle> Bundles = new()
        {
            new ReleaseBundle { Id = 1, Name = "Bundle A", Status = "PLANNED" },
            new ReleaseBundle { Id = 2, Name = "Bundle B", Status = "PLANNED" },
            new ReleaseBundle { Id = 3, Name = "Bundle X", Status = "RELEASED", ReleaseDate = "2025-08-01" },
            new ReleaseBundle { Id = 4, Name = "Bundle Y", Status = "RELEASED", ReleaseDate = "2025-08-10" }
        };

        [HttpGet("{bundleId}")]
        public ActionResult<ChecklistResponse> GetChecklist(int bundleId)
        {
            var bundle = Bundles.FirstOrDefault(b => b.Id == bundleId);
            if (bundle == null)
                return NotFound(new { message = $"No bundle found with id {bundleId}" });

            if (!Checklists.TryGetValue(bundleId, out var checklist))
                return NotFound(new { message = $"No checklist found for bundle {bundleId}" });

            var response = new ChecklistResponse
            {
                BundleId = bundle.Id,
                Name = bundle.Name,
                Checklist = checklist
            };

            return Ok(response);
        }
    }
}
