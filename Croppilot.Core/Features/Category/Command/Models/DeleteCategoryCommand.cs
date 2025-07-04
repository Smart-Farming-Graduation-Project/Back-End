﻿using Croppilot.Core.Bases;
using MediatR;

namespace Croppilot.Core.Features.Category.Command.Models
{
    public class DeleteCategoryCommand(int id) : IRequest<Response<string>>
    {
        public int Id { get; set; } = id;
    }
}
