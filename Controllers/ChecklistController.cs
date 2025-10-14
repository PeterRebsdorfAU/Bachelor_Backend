using Bachelor_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Bachelor_Backend.Data;

[ApiController]
[Route("api/[controller]")]
public class ChecklistController : ControllerBase
{
    [HttpGet("{bundleId}")]
    public ActionResult<ChecklistResponse> GetChecklist(int bundleId)
    {
        var bundle = DataChecklistAccessor.Bundles.FirstOrDefault(b => b.Id == bundleId);
        if (bundle == null)
            return NotFound(new { message = $"No bundle found with id {bundleId}" });

        if (!DataChecklistAccessor.Checklists.TryGetValue(bundleId, out var sections))
            return NotFound(new { message = $"No checklist found for bundle {bundleId}" });

        var response = new ChecklistResponse
        {
            BundleId = bundle.Id,
            Name = bundle.Name,
            Sections = sections
        };

        return Ok(response);
    }
}
