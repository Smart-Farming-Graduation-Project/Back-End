namespace Croppilot.Core.Features.Dashbored.Field.Results
{

    public record GetFieldByIdResult(
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
