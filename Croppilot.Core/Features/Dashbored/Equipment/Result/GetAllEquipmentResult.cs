namespace Croppilot.Core.Features.Dashbored.Equipment.Result
{
    public record GetAllEquipmentResult(
        string EquipmentId,
        string EquipmentName,
        string Status,
        DateTime LastMaintenance,
        double HoursUsed,
        double Battery,
        string Connectivity
    );
}
