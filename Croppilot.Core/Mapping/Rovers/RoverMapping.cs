using Croppilot.Core.Features.Rovers.Query.Result;
using Croppilot.Date.Models;
using Mapster;

namespace Croppilot.Core.Mapping.Rovers;

public class RoverMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Rover, GetRoverResponse>()
            .Map(dest => dest.UserName, src => src.User.UserName);
    }
} 