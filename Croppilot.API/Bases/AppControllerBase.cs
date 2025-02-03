﻿using Croppilot.Core.Bases;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Croppilot.API.Bases;

[Route("api/[controller]")]
[ApiController]
public class AppControllerBase : ControllerBase
{
    public ObjectResult NewResult<T>(Response<T> response)
    {
        return response.StatusCode switch
        {
            HttpStatusCode.OK => new OkObjectResult(response),
            HttpStatusCode.Created => new CreatedResult(string.Empty, response),
            HttpStatusCode.Unauthorized => new UnauthorizedObjectResult(response),
            HttpStatusCode.BadRequest => new BadRequestObjectResult(response),
            HttpStatusCode.NotFound => new NotFoundObjectResult(response),
            HttpStatusCode.Accepted => new AcceptedResult(string.Empty, response),
            HttpStatusCode.UnprocessableEntity => new UnprocessableEntityObjectResult(response),
            _ => new BadRequestObjectResult(response)
        };
    }
}