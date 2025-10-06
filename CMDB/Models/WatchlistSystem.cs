namespace Bachelor_Backend.Models
{
    public class WatchlistSystem
    {
        public string Name { get; set; } = "";
        public List<string> Steps { get; set; } = new();
        public string Current { get; set; } = "";
        public string Arc { get; set; } = "";
    }
}
