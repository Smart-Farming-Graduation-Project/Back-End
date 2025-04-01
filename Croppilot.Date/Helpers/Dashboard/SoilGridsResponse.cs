namespace Croppilot.Date.Helpers.Dashboard
{
    public class SoilGridsResponse
    {
        public string Type { get; set; } = string.Empty;
        public Geometry Geometry { get; set; } = new Geometry();
        public SoilProperties Properties { get; set; } = new SoilProperties();
        public double Query_time_s { get; set; }
    }


    public class Geometry
    {
        public string Type { get; set; } = string.Empty;
        public double[] Coordinates { get; set; } = Array.Empty<double>();
    }

    public class SoilProperties
    {
        public List<SoilLayer> Layers { get; set; } = new List<SoilLayer>();
    }
    public class SoilLayer
    {
        public string Name { get; set; } = string.Empty;
        public UnitMeasure Unit_measure { get; set; } = new UnitMeasure();
        public List<SoilDepth> Depths { get; set; } = new List<SoilDepth>();
    }

    public class UnitMeasure
    {
        public double D_factor { get; set; }
        public string Mapped_units { get; set; } = string.Empty;
        public string Target_units { get; set; } = string.Empty;
        public string Uncertainty_unit { get; set; } = string.Empty;
    }

    public class SoilDepth
    {
        public DepthRange Range { get; set; } = new DepthRange();
        public string Label { get; set; } = string.Empty;
        public DepthValues Values { get; set; } = new DepthValues();
    }

    public class DepthRange
    {
        public double Top_depth { get; set; }
        public double Bottom_depth { get; set; }
        public string Unit_depth { get; set; } = string.Empty;
    }
    public class DepthValues
    {
        public double Mean { get; set; }
    }
}
