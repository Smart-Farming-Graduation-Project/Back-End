namespace Croppilot.Date.Models.AiModel
{
    public class FeedbackEntry
    {

        public int Id { get; set; }
        public string Disease { get; set; }
        public string Solution { get; set; }

        public int ModelResultId { get; set; }
        public ModelResult ModelResult { get; set; }
    }
}
