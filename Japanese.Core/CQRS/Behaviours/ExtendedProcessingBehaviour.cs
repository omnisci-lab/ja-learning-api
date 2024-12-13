using Japanese.Core.CQRS.ExtendedProcessing;
using MediatR;

namespace Japanese.CQRS.Behaviours;

public class ExtendedProcessingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly ExtProcManager _pluginManager;

    public ExtendedProcessingBehaviour(ExtProcManager pluginManager)
    {
        _pluginManager = pluginManager;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        TResponse? response = await next();
        _pluginManager.ExecutePlugins(request, response);

        return response;
    }
}