using System.Net;

namespace Beheviors
{
    public class ValidatorBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(
                validators.Select(v => v.ValidateAsync(context, cancellationToken))
            );

            var failures = validationResults
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Any())
            {
                var errorDictionary = new Dictionary<string, object>();

                foreach (var failure in failures)
                {
                    if (!string.IsNullOrWhiteSpace(failure.PropertyName))
                    {
                        if (errorDictionary.ContainsKey(failure.PropertyName))
                        {
                            if (errorDictionary[failure.PropertyName] is List<string> errorList)
                            {
                                errorList.Add(failure.ErrorMessage);
                            }
                            else
                            {
                                errorDictionary[failure.PropertyName] = new List<string>
                                {
                                    errorDictionary[failure.PropertyName].ToString(),
                                    failure.ErrorMessage
                                };
                            }
                        }
                        else
                        {
                            errorDictionary[failure.PropertyName] = failure.ErrorMessage;
                        }
                    }
                    else
                    {
                        if (!errorDictionary.ContainsKey("GeneralErrors"))
                        {
                            errorDictionary["GeneralErrors"] = new List<string>();
                        }
                        ((List<string>)errorDictionary["GeneralErrors"]).Add(failure.ErrorMessage);
                    }
                }
                var validatorNames = validators.Select(v => v.GetType().Name).ToList();

                if (typeof(TResponse).IsGenericType && typeof(TResponse).GetGenericTypeDefinition() == typeof(Response<>))
                {
                    var responseType = typeof(TResponse).GetGenericArguments()[0]; // Extract T from Response<T>
                    var responseInstance = Activator.CreateInstance(typeof(Response<>).MakeGenericType(responseType), new object?[] { default, "Validation Failed" });


                    if (responseInstance != null)
                    {
                        var response = (dynamic)responseInstance;
                        response.StatusCode = HttpStatusCode.BadRequest;
                        response.Succeeded = false;
                        response.Message = failures.Any()
                            ? failures.Select(x => $"{x.PropertyName}: {x.ErrorMessage}").First()
                            : "Validation failed.";
                        response.Meta = new Dictionary<string, object>
                        {

                            { "Errors", errorDictionary  }
                        };
                        response.Data = "No Data Just Errors hahahahaahahah ";
                        return (TResponse)response;
                    }
                }

                throw new ValidationException(failures);
            }

            return await next();
        }
    }
}
