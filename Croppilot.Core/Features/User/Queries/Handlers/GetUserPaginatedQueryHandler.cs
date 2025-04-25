using Croppilot.Core.Features.User.Queries.Models;
using Croppilot.Core.Features.User.Queries.Result;
using Croppilot.Date.Identity;
using Croppilot.Infrastructure.Comman;
using Microsoft.AspNetCore.Identity;

namespace Croppilot.Core.Features.User.Queries.Handlers
{
    internal class GetUserPaginatedQueryHandler(UserManager<ApplicationUser> userManager)
        : ResponseHandler, IRequestHandler<GetUserPaginatedQuery, Response<List<GetUser>>>
    {
        public async Task<Response<List<GetUser>>> Handle(GetUserPaginatedQuery request, CancellationToken cancellationToken)
        {
            var response = await userManager.Users
                .Select(u => new GetUser
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    FullName = $"{u.FirstName} {u.LastName}",
                    Address = u.Address,
                    Phone = u.Phone,
                    UserName = u.UserName,
                    Email = u.Email
                }).ToPaginatedListAsync(request.pageNumber, request.pageSize);

            var userMeta = new Dictionary<string, object>
            {
                {"Current Page", response.CurrentPage},
                {"Total Pages", response.TotalPages},
                {"Page Size", response.PageSize},
                {"Total Count", response.TotalCount},
                {"Has Next", response.HasNextPage},
                {"Has Previous", response.HasPreviousPage},
                {"Meta", response.Meta},
                {"Succeeded", response.Succeeded},
                {"Message", response.Messages}
            };
            return Success(response.Data, meta: userMeta);
        }
    }
}
