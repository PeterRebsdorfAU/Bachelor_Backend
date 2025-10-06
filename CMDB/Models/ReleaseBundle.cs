namespace Bachelor_Backend.Models
{
    public class ReleaseBundle
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Status { get; set; } = "";
        public string? ReleaseDate { get; set; }
        public List<string>? Customers { get; set; }
        public List<SystemEntry>? Systems { get; set; }   // ændret fra string til SystemEntry
    }
}
