namespace Croppilot.Date.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public string UserID { get; set; }
        public int ProductID { get; set; }
        public string Headline { get; set; }
        public double Rating { get; set; }
        public string? ReviewText { get; set; }
        public DateTime ReviewDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } = null;

        public ApplicationUser User { get; set; }
        public Product Product { get; set; }
    }
}