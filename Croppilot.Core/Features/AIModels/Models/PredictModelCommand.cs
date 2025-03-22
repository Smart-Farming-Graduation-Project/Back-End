using Croppilot.Core.Features.AIModels.Results;

namespace Croppilot.Core.Features.AIModels.Models
{
    public class PredictModelCommand : IRequest<Response<ModelResults>>
    {
        public IFormFile Image { get; set; }
    }
}
