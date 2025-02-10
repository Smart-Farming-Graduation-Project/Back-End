using Croppilot.Core.Bases;
using MediatR;

namespace Croppilot.Core.Features.User.Commands.Models
{
    public class EditUserCommand : IRequest<Response<string>>
    {
        public required string Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string UserName { get; set; }
        public required string Phone { get; set; }
        public required string Address { get; set; }
    }
}
