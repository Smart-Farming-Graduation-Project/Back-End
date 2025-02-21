using System.Net;

namespace Croppilot.Core.Behaviors
{
    public class ValidatorBehavior<TRequest, TResponse>(
        IEnumerable<IValidator<TRequest>> validators)
        : IPipelineBehavior<TRequest, Response<string>>
        where TRequest : IRequest<Response<string>>
    {
        public async Task<Response<string>> Handle(
            TRequest request,
            RequestHandlerDelegate<Response<string>> next,
            CancellationToken cancellationToken)
        {
            if (validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(
                    validators.Select(v => v.ValidateAsync(context, cancellationToken))
                );

                var failures = validationResults
                    .SelectMany(r => r.Errors)
                    .Where(f => f != null)
                    .ToList();

                if (failures.Count > 0)
                {
                    return new Response<string>
                    {
                        Succeeded = false,
                        StatusCode = (HttpStatusCode)StatusCodes.Status400BadRequest,
                        Message = failures.Any()
                            ? failures.Select(x => $"{x.PropertyName}: {x.ErrorMessage}").First()
                            : "Validation failed."
                    };
                }
            }

            return await next();
        }
    }
}