namespace Bachelor_Backend.Models
{
    public class BundleScope
    {
        public int BundleId { get; set; }
        public string BundleName { get; set; } = "";
        public List<SystemEntry> Systems { get; set; } = new();
    }
}
