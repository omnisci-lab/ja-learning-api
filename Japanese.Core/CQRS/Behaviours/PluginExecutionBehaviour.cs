using Japanese.Core.Plugin;
using MediatR;

namespace Japanese.CQRS.Behaviours;

public class PluginExecutionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly PluginManager _pluginManager;

    public PluginExecutionBehaviour(PluginManager pluginManager)
    {
        _pluginManager = pluginManager;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        List<PluginInfo> pluginInfo = _pluginManager.GetList();

        TResponse? response = await next();

        return response;
    }
}