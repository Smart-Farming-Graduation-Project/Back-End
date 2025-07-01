namespace Croppilot.Services.Abstract.EmbbeddedServices
{
    public interface IRoverPhotoServices
    {
        Task<string> UploadImageAsync(Stream imageStream, string blobName);
        Task<List<Uri>> GetAllImageUrisWithAiAsync();
        Task<List<Uri>> GetAllImageUrisWithNoAiAsync();
    }
}