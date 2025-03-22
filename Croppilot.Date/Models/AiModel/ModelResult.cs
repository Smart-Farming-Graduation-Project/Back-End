namespace Croppilot.Date.Models.AiModel
{
    public class ModelResult
    {
        [Key]
        public int Id { get; set; }
        public Guid ImageId { get; set; }
        public string ImageUrl { get; set; }
        public List<FeedbackEntry> FeedbackEntries { get; set; } = new List<FeedbackEntry>();
    }
}
