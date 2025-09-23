namespace Bachelor_Backend.Models
{
    public class ReleaseBundle
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = "PLANNED";
        public string? ReleaseDate { get; set; }

        // 🔹 nye felter
        public List<string> Customers { get; set; } = new();
        public List<string> Systems { get; set; } = new();
    }
}
