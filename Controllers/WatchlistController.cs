using Microsoft.AspNetCore.Mvc;
using Bachelor_Backend.Models;
using Bachelor_Backend.Data;

namespace Bachelor_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WatchlistController : ControllerBase
    {
        private static readonly Dictionary<int, WatchlistResponse> WatchlistData = WatchlistDataAccessor.WatchlistData;

        [HttpGet("{bundleId}")]
        public ActionResult<WatchlistResponse> GetWatchlist(int bundleId)
        {
            if (!WatchlistData.TryGetValue(bundleId, out var watchlist))
                return NotFound(new { message = $"No watchlist found for bundle {bundleId}" });

            return Ok(watchlist);
        }
    }
}
