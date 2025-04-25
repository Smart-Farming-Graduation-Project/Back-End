namespace Croppilot.Date.Helpers.Dashboard.Enum
{
    using System.Text.Json.Serialization;

    public enum EmergencyType
    {
        [JsonPropertyName("equipment")]
        EquipmentFailure,
        [JsonPropertyName("medical")]
        MedicalEmergency,
        [JsonPropertyName("fire")]
        Fire,
        [JsonPropertyName("weather")]
        SevereWeather,
        [JsonPropertyName("pest")]
        Pest,
        [JsonPropertyName("irrigation")]
        Irrigation,
        [JsonPropertyName("soil")]
        Soil,
        [JsonPropertyName("other")]
        Other
    }
}
