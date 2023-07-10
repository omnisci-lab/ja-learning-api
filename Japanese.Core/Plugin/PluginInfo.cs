using System.Reflection;

namespace Japanese.Core.Plugin;

public class PluginInfo
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Version { get; set; }

    public Assembly? Assembly { get; set; }
}
