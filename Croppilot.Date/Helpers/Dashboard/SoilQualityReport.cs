namespace Croppilot.Date.Helpers.Dashboard
{
    public class SoilQualityReport
    {
        public SoilProperty Moisture { get; set; }
        public SoilProperty PH { get; set; }
        public SoilProperty ClayContent { get; set; }
        public SoilProperty OrganicCarbon { get; set; }
        public string QualityRating { get; set; }
    }
}
