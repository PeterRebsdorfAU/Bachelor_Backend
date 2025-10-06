namespace Bachelor_Backend.Models
{
    public class ChecklistResponse
    {
            public int BundleId { get; set; }
            public string Name { get; set; } = string.Empty;
            public List<string> Checklist { get; set; } = new();

}
}
