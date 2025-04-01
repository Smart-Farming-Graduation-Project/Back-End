namespace Croppilot.Services.Services.DashboredServices.Helper
{
    public static class SoilMethods
    {
        public static double CalculateTextureScore(double clayPercent)
        {
            // Optimal range: 20-35% clay (loam to clay loam)
            return Math.Clamp(100 - Math.Abs(clayPercent - 27.5) * 4, 0, 100);
        }

        public static double CalculateOrganicScore(double organicPercent)
        {
            // Optimal range: 2-5%
            return Math.Clamp(organicPercent * 25, 0, 100); // 4% = 100
        }
        public static double CalculateMoistureScore(double moisture)
        {
            // Optimal range: 0.25-0.35 cm³/cm³
            return Math.Clamp(100 - (Math.Abs(moisture - 0.3) * 500), 0, 100);
        }

        public static double CalculatePHScore(double ph)
        {
            // Optimal range: 6.0-7.5
            if (ph >= 6.0 && ph <= 7.5) return 100;
            if (ph >= 5.5 && ph < 6.0) return 80 - (6.0 - ph) * 40;
            if (ph > 7.5 && ph <= 8.0) return 80 - (ph - 7.5) * 40;
            return 0;
        }
    }
}
