using Bachelor_Backend.Models;

namespace Bachelor_Backend.Data
{
    public static class WatchlistDataAccessor
    {
        public static Dictionary<int, WatchlistResponse> WatchlistData { get; } = new()
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
    }
}
