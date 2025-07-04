using Croppilot.Core.Features.Rovers.Query.Models;
using Croppilot.Core.Features.Rovers.Query.Result;
using Croppilot.Services.Abstract.EmbbeddedServices;
using System.Text.RegularExpressions;

namespace Croppilot.Core.Features.Rovers.Query.Handlers;

public class RoverQueryHandler(IRoverService roverService, IRoverPhotoServices roverPhotoServices, IUserService userService) : ResponseHandler,
    IRequestHandler<GetUserRoversQuery, Response<List<GetRoverResponse>>>,
    IRequestHandler<GetRoverByIdQuery, Response<GetRoverResponse>>,
    IRequestHandler<GetAllRoversQuery, Response<List<GetRoverResponse>>>,
    IRequestHandler<GetAllRoverPhoto, Response<List<GetAllBlobPhoto>>>,
    IRequestHandler<GetPredictedRoverPhoto, Response<List<GetAllBlobPhoto>>>
{
    public async Task<Response<List<GetRoverResponse>>> Handle(GetUserRoversQuery query, CancellationToken cancellationToken)
    {
        string? userId = query.UserId;

        // If username is provided, get the user ID from it
        if (!string.IsNullOrEmpty(query.UserName))
        {
            var user = await userService.GetUserByUserName(query.UserName);
            if (user == null)
                return NotFound<List<GetRoverResponse>>($"User with username '{query.UserName}' not found.");

            userId = user.Id;
        }

        if (string.IsNullOrEmpty(userId))
            return BadRequest<List<GetRoverResponse>>("Either UserId or UserName must be provided.");

        var rovers = await roverService.GetRoversByUserIdAsync(userId, cancellationToken);

        var roverResponses = rovers.Select(r => new GetRoverResponse
        {
            Id = r.Id,
            UserId = r.UserId,
            CreatedAt = r.CreatedAt,
            UserName = r.User?.UserName ?? string.Empty
        }).ToList();

        return Success(roverResponses);
    }

    public async Task<Response<GetRoverResponse>> Handle(GetRoverByIdQuery query, CancellationToken cancellationToken)
    {
        var rover = await roverService.GetRoverByIdAsync(query.RoverId, cancellationToken);

        if (rover == null)
            return NotFound<GetRoverResponse>("Rover not found.");

        var roverResponse = new GetRoverResponse
        {
            Id = rover.Id,
            UserId = rover.UserId,
            CreatedAt = rover.CreatedAt,
            UserName = rover.User?.UserName ?? string.Empty
        };

        return Success(roverResponse);
    }

    public async Task<Response<List<GetRoverResponse>>> Handle(GetAllRoversQuery query, CancellationToken cancellationToken)
    {
        var rovers = await roverService.GetAllRoversAsync(cancellationToken);

        var roverResponses = rovers.Select(r => new GetRoverResponse
        {
            Id = r.Id,
            UserId = r.UserId,
            CreatedAt = r.CreatedAt,
            UserName = r.User?.UserName ?? string.Empty
        }).ToList();

        return Success(roverResponses);
    }

    public async Task<Response<List<GetAllBlobPhoto>>> Handle(GetAllRoverPhoto request, CancellationToken cancellationToken)
    {

        var roverPhoto = await roverPhotoServices.GetAllImageUrisWithNoAiAsync();

        var roverResponses = roverPhoto.Select(uri => new GetAllBlobPhoto
        {
            PhotoUrl = uri.ToString(),
            CreatedDate = Convert.ToDateTime(ExtractDateFromBlobName(uri)?.ToString("yyyy-MM-dd HH:mm:ss") ?? "Unknown")
        }).ToList();

        return Success(roverResponses);
    }

    public async Task<Response<List<GetAllBlobPhoto>>> Handle(GetPredictedRoverPhoto request, CancellationToken cancellationToken)
    {
        var roverPhoto = await roverPhotoServices.GetAllImageUrisWithAiAsync();

        var roverResponses = roverPhoto.Select(uri => new GetAllBlobPhoto
        {
            PhotoUrl = uri.ToString(),
            CreatedDate = Convert.ToDateTime(ExtractDateFromBlobName(uri)?.ToString("yyyy-MM-dd HH:mm:ss") ?? "Unknown")
        }).ToList();

        return Success(roverResponses);
    }



    private DateTime? ExtractDateFromBlobName(Uri uri)
    {
        var fileName = Path.GetFileNameWithoutExtension(uri.LocalPath);

        var match = Regex.Match(fileName, @"(\d{4}-\d{2}-\d{2}_\d{2}-\d{2}-\d{2})");
        if (match.Success)
        {
            if (DateTime.TryParseExact(match.Value, "yyyy-MM-dd_HH-mm-ss", null, System.Globalization.DateTimeStyles.None, out var date))
            {
                return date;
            }
        }

        return null;
    }


}