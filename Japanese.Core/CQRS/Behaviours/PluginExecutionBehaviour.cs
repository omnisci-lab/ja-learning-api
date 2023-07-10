using MediatR;

namespace Japanese.CQRS.Behaviours;

public class PluginExecutionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    public PluginExecutionBehaviour()
    {

    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        TResponse? response = await next();

        return response;
    }
}
