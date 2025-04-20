namespace Croppilot.Date.Models.DashboardModels
{
    public class CropYield
    {
        public int Id { get; set; }
        public string Month { get; set; }
        public int Yield { get; set; }
        public int Target { get; set; }
        public int Rainfall { get; set; }

        //public int FieldId { get; set; }
        //public Field Field { get; set; }
    }
}
