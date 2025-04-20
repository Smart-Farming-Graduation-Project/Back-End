namespace Croppilot.Date.Models.DashboardModels
{
    public class SoilMoisture
    {
        public int Id { get; set; }
        public string FieldName { get; set; }
        public int Moisture { get; set; }
        public int Optimal { get; set; }
        public float PH { get; set; }

        public int FieldId { get; set; }
        public Field Field { get; set; }
    }
}
