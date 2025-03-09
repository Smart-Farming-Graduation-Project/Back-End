using Croppilot.Core.Features.Comments.Command.Models;
using Croppilot.Date.Models;
using Croppilot.Infrastructure.Extensions;

namespace Croppilot.Core.Features.Comments.Command.Handlers;

public class CommentCommandHandler(
    ICommentService commentService,
    IHttpContextAccessor contextAccessor) :
    ResponseHandler,
    IRequestHandler<AddCommentCommand, Response<string>>,
    IRequestHandler<UpdateCommentCommand, Response<string>>,
    IRequestHandler<DeleteCommentCommand, Response<string>>
{
    public async Task<Response<string>> Handle(AddCommentCommand command, CancellationToken cancellationToken)
    {
        var userId = contextAccessor.HttpContext?.User.GetUserId()!;
        // If ParentCommentId is 0, treat it as no parent.
        if (command.ParentCommentId == 0)
            command.ParentCommentId = null;

        var comment = command.Adapt<Comment>();
        comment.UserId = userId;

        var result = await commentService.AddCommentAsync(comment, cancellationToken);
        return result == OperationResult.Success
            ? Success<string>("Comment created successfully.")
            : BadRequest<string>("Failed to create comment.");
    }

    public async Task<Response<string>> Handle(UpdateCommentCommand command, CancellationToken cancellationToken)
    {
        var userId = contextAccessor.HttpContext?.User.GetUserId()!;
        var currentComment = await commentService.GetCommentByIdAsync(command.Id, cancellationToken);
        if (currentComment == null)
            return NotFound<string>("Comment not found.");
        if (currentComment.UserId != userId)
            return Unauthorized<string>("You are not authorized to update this comment.");
        
        var comment = command.Adapt<Comment>();
        comment.UserId = userId;
        var result = await commentService.UpdateCommentAsync(comment, cancellationToken);
        return result == OperationResult.Success
            ? Success<string>("Comment updated successfully.")
            : BadRequest<string>("Failed to update comment.");
    }

    public async Task<Response<string>> Handle(DeleteCommentCommand command, CancellationToken cancellationToken)
    {
        var userId = contextAccessor.HttpContext?.User.GetUserId()!;
        var comment = await commentService.GetCommentByIdAsync(command.Id, cancellationToken);
        if (comment!.UserId != userId)
            return Unauthorized<string>("You are not authorized to delete this comment.");

        var result = await commentService.DeleteCommentAsync(command.Id, cancellationToken);
        return result == OperationResult.Success
            ? Success<string>("Comment deleted successfully.")
            : BadRequest<string>("Failed to delete comment.");
    }
}