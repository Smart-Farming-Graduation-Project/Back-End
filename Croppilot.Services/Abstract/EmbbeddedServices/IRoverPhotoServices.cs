namespace Croppilot.Services.Abstract.EmbbeddedServices
{
    public interface IRoverPhotoServices
    {
        Task<string> UploadImageAsync(Stream imageStream, string blobName);
    }
}