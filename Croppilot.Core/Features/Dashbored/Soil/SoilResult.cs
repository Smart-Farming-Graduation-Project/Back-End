namespace Croppilot.Core.Features.Dashbored.Soil
{
    public class SoilResult
    {
        public int Id { get; set; }
        public string FieldName { get; set; }
        public int Moisture { get; set; }
        public int Optimal { get; set; }
        public float PH { get; set; }
        //public FieldDTO Field { get; set; }
    }

    //public class FieldDTO
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
