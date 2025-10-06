using Microsoft.AspNetCore.Mvc;
using Bachelor_Backend.Models;

namespace Bachelor_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WatchlistController : ControllerBase
    {
        // Dummy data (kan evt. flyttes til en fælles Accessor som de andre controllers bruger)
        private static readonly Dictionary<int, WatchlistResponse> WatchlistData = new()
        {
            {
                1,
                new WatchlistResponse
                {
                    BundleId = 1,
                    BundleName = "Bundle A",
                    Bundle = new WatchlistBundle
                    {
                        Steps = new List<string> { "IBD", "TRE", "TCE", "WPE", "FIN" },
                        Current = "TRE"
                    },
                    Systems = new List<WatchlistSystem>
                    {
                        new() { Name = "Task system", Steps = new() { "RP", "TRE", "TCE", "WPE", "R" }, Current = "R", Arc = "ARC 1.3.6.1234" },
                        new() { Name = "Broker system", Steps = new() { "RP", "TRE", "TCE", "WPE", "R" }, Current = "WPE", Arc = "ARC 24.5.2.633" },
                        new() { Name = "Patient system", Steps = new() { "RP", "TRE", "TCE", "WPE", "R" }, Current = "TRE", Arc = "ARC 2.35.32.11" }
                    },
                    PlannedBundle = new WatchlistBundle
                    {
                        Steps = new List<string> { "Bundle planned", "Bundle ready to fill", "Bundle finished" },
                        Current = "Bundle planned"
                    },
                    Delivery = new WatchlistBundle
                    {
                        Steps = new List<string> { "Delivery planned", "Delivery delivered", "Delivery confirmed", "Delivery finished" },
                        Current = "Delivery planned"
                    }
                }
            }
        };

        [HttpGet("{bundleId}")]
        public ActionResult<WatchlistResponse> GetWatchlist(int bundleId)
        {
            if (!WatchlistData.TryGetValue(bundleId, out var watchlist))
                return NotFound(new { message = $"No watchlist found for bundle {bundleId}" });

            return Ok(watchlist);
        }
    }
}
