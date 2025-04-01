namespace Croppilot.Core.Features.Dashbored.Field.Results
{

    public record GetAllFieldResults(
        int FieldId,
        string FieldName,
        double FieldSize,
        string CropName,
        DateTime PlantingDate,
        DateTime HarvestDate,
        string Irrigation,
        string Status
    );
}
