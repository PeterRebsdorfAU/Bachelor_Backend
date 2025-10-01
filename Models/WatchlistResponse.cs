namespace Bachelor_Backend.Models
{
    public class WatchlistResponse
    {
        public int BundleId { get; set; }
        public string BundleName { get; set; } = "";

        public WatchlistBundle? Bundle { get; set; }
        public List<WatchlistSystem> Systems { get; set; } = new();
        public WatchlistBundle? PlannedBundle { get; set; }
        public WatchlistBundle? Delivery { get; set; }
    }
}
