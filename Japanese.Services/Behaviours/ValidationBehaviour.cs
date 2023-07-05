using FluentValidation;
using FluentValidation.Results;
using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using MediatR;
using ValidationException = FluentValidation.ValidationException;

namespace Japanese.Services.Behaviours;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            ValidationContext<TRequest> context = new ValidationContext<TRequest>(request);

            ValidationResult[] validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
            List<ValidationFailure> failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

            if (failures.Count != 0)
            {
                if (typeof(TResponse) == typeof(ExecResult))
                    return (TResponse)Convert.ChangeType(
                        new ExecResult { 
                            Status = ExecStatus.Invalid,
                            Message = string.Join(" | ", failures.Select(p => p.ErrorMessage))
                        }, 
                        typeof(TResponse)
                    );

                if (typeof(TResponse).IsGenericType && typeof(TResponse).GetGenericTypeDefinition() == typeof(ExecResult<>))
                {
                    object execResult = Activator.CreateInstance(typeof(TResponse))!;
                    Type execResultType = execResult.GetType();
                    execResultType.GetProperty(nameof(ExecResult.Status))?.SetValue(execResult, ExecStatus.Invalid);
                    execResultType.GetProperty(nameof(ExecResult.Message))?.SetValue(execResult, string.Join(" | ", failures.Select(p => p.ErrorMessage)));

                    return (TResponse)execResult;
                }

                throw new ValidationException(failures);
            }
        }
        return await next();
    }
}