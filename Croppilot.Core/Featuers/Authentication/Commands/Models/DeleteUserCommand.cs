using Croppilot.Core.Bases;
using MediatR;

namespace Croppilot.Core.Featuers.Authentication.Commands.Models
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
