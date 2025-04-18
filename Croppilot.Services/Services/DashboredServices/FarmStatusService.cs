using Croppilot.Date.Helpers.Dashboard;
using Croppilot.Infrastructure.Comman;
using Croppilot.Services.Abstract.DashboredServices;
using Croppilot.Services.Services.DashboredServices.Helper;
using System.Net.Http.Json;

namespace Croppilot.Services.Services.DashboredServices
{
    public class FarmStatusService(IHttpClientFactory clientFactory, IEquipmentService equipmentService, IFieldService fieldService) : IFarmStatusService
    {
        public async Task<SoilQualityReport> GetSoilQualityReportAsync(double latitude, double longitude)
        {
            var httpClient = clientFactory.CreateClient();

            var moistureTask = GetSoilProperty("wv0033", latitude, longitude);  // Field capacity
            var phTask = GetSoilProperty("phh2o", latitude, longitude);         // pH in water
            var clayTask = GetSoilProperty("clay", latitude, longitude);        // Clay content
            var organicTask = GetSoilProperty("ocd", latitude, longitude);      // Organic carbon

            await Task.WhenAll(moistureTask, phTask, clayTask, organicTask);

            return new SoilQualityReport
            {
                Moisture = await moistureTask,
                PH = await phTask,
                ClayContent = await clayTask,
                OrganicCarbon = await organicTask,
                QualityRating = CalculateQualityRating(
                    await moistureTask,
                    await phTask,
                    await clayTask,
                    await organicTask)
            };
        }

        public async Task<FarmStatusDto> GetFarmStatus()
        {
            var soilTask = await GetSoilQualityReportAsync(SD.Latitude, SD.Longitude);
            var equipmentTask = await equipmentService.GetActiveEquipmentCount();
            var irrigationTask = await fieldService.GetMostUsedIrrigationTypeAsync();


            if (soilTask == null)
            {
                return new FarmStatusDto
                {
                    ActiveMachines = 0,
                    IrrigationStatus = "Inactive",
                    SoilQuality = "Unknown",
                    CropHealth = "Unknown",
                    PestRisk = "Unknown",
                    WaterReservoir = 0
                };
            }

            return new FarmStatusDto
            {
                ActiveMachines = equipmentTask,
                IrrigationStatus = irrigationTask?.ToString() ?? "Unknown",
                SoilQuality = soilTask.QualityRating,
                CropHealth = "Good",
                PestRisk = "Low",
                WaterReservoir = 80
            };
        }



        private async Task<SoilProperty> GetSoilProperty(string property, double lat, double lon)
        {
            try
            {
                var url = $"https://rest.isric.org/soilgrids/v2.0/properties/query?" +
                         $"lon={lon}&lat={lat}&property={property}&depth=0-5cm&value=mean";

                //var response = await clientFactory.CreateClient()
                //    .GetFromJsonAsync<SoilGridsResponse>(url);

                var client = clientFactory.CreateClient();
                var httpResponse = await client.GetAsync(url);

                if (!httpResponse.IsSuccessStatusCode)
                {
                    return new SoilProperty { Value = 0, Available = false };
                }

                var response = await httpResponse.Content.ReadFromJsonAsync<SoilGridsResponse>();
                var meanValue = response?.Properties?.Layers?
                    .FirstOrDefault()?
                    .Depths?
                    .FirstOrDefault()?
                    .Values?
                    .Mean;

                if (!meanValue.HasValue)
                    return new SoilProperty { Value = 0, Available = false };

                double value = property switch
                {
                    "wv0033" => meanValue.Value / 100,  // Convert to cm³/cm³
                    "phh2o" => meanValue.Value / 10,   // Convert to pH units
                    _ => meanValue.Value               // Others are in standard units
                };

                return new SoilProperty { Value = value, Available = true };
            }
            catch (Exception ex)
            {
                return new SoilProperty { Value = 0, Available = false };
            }
        }
        private string CalculateQualityRating(
        SoilProperty moisture,
        SoilProperty ph,
        SoilProperty clay,
        SoilProperty organicCarbon)
        {
            if (!moisture.Available || !ph.Available || !clay.Available || !organicCarbon.Available)
                return "Unknown";

            double moistureScore = SoilMethods.CalculateMoistureScore(moisture.Value);
            double phScore = SoilMethods.CalculatePHScore(ph.Value);
            double textureScore = SoilMethods.CalculateTextureScore(clay.Value);
            double organicScore = SoilMethods.CalculateOrganicScore(organicCarbon.Value);
            double totalScore = (moistureScore * 0.3) +
                              (phScore * 0.25) +
                              (textureScore * 0.25) +
                              (organicScore * 0.2);

            return totalScore switch
            {
                > 80 => "Excellent",
                > 60 => "Good",
                > 40 => "Fair",
                _ => "Poor"
            };
        }
    }
}
