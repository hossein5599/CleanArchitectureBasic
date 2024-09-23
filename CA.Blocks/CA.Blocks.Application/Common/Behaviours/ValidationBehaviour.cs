using CA.Blocks.Application.Common.Exceptions;
using FluentValidation;
using MediatR;
using FluentValidation.Results;
using Humanizer;
namespace CA.Blocks.Application.Common.Behaviours;

public class ValidationBehaviour<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken = default)
    {
        if (validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResult = await validators.First().ValidateAsync(context, cancellationToken);

            if (!validationResult.IsValid)
            {
                var failures = Serialize(validationResult.Errors);
                throw new BadRequestException(Resources.Messages.BadRequest, failures);
            }
        }
        return await next();
    }

    private static Dictionary<string, string[]> Serialize(IEnumerable<ValidationFailure> failures)
    {
        var camelCaseFailures = failures
            .GroupBy(failure => failure.PropertyName.Camelize())
            .ToDictionary(
                group => group.Key,
                group => group.Select(failure => failure.ErrorMessage).ToArray()
            );

        return camelCaseFailures;
    }
}

//public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
//     where TRequest : notnull
//{
//    private readonly IEnumerable<IValidator<TRequest>> _validators;

//    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
//    {
//        _validators = validators;
//    }

//    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
//    {
//        if (_validators.Any())
//        {
//            var context = new ValidationContext<TRequest>(request);

//            var validationResults = await Task.WhenAll(
//                _validators.Select(v =>
//                    v.ValidateAsync(context, cancellationToken)));

//            var failures = validationResults
//                .Where(r => r.Errors.Any())
//                .SelectMany(r => r.Errors)
//                .ToList();

//            if (failures.Any())
//                throw new ValidationException(failures);
//        }
//        return await next();
//    }
//}