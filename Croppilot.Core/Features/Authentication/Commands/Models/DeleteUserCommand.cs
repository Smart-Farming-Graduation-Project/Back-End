using Croppilot.Core.Bases;
using MediatR;

namespace Croppilot.Core.Features.Authentication.Commands.Models
{
	public class DeleteUserCommand : IRequest<Response<string>>
	{
		public string Id { get; set; }
		public DeleteUserCommand(string id)
		{
			Id = id;
		}
	}
}
