namespace Bachelor_Backend.Models
{
    public class ReleaseBundle
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty; // "planned", "released"
        public string? ReleaseDate { get; set; }
        
    }
}
