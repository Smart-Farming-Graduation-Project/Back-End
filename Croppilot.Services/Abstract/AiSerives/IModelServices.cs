using Croppilot.Date.Models.AiModel;
using Microsoft.AspNetCore.Http;

namespace Croppilot.Services.Abstract.AiSerives
{
    public interface IModelServices
    {
        Task<ModelResult> UploadPhotoToModel(IFormFile imagePath);
        Task<ModelResult?> GetFeedback(Guid imageId);
        //Task<bool> GetFeedbackFromBot(Guid imageId);
    }
}
