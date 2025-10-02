namespace Bachelor_Backend.Models
{
    public class ChecklistResponse
    {
        public int BundleId { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<ChecklistSection> Sections { get; set; } = new();
    }

    public class ChecklistSection
    {
        public string Title { get; set; } = string.Empty;
        public List<Checklist> Items { get; set; } = new();
    }

    public class Checklist
    {
        public string Text { get; set; } = string.Empty;
        public bool IsChecked { get; set; }

        // Ny: hver item kan have sin egen under-checkliste
        public List<ChecklistItem> SubItems { get; set; } = new();
    }

    public class ChecklistItem
    {
        public string Text { get; set; } = string.Empty;
        public bool IsChecked { get; set; }
    }
}
