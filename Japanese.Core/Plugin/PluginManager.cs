using System.Reflection;

namespace Japanese.Core.Plugin;

public class PluginManager
{
    private readonly PluginCollection _pluginCollection;

    public PluginManager(PluginCollection pluginCollection)
    {
        _pluginCollection = pluginCollection;
    }

    public void Load()
    {
        _pluginCollection.Clear();
        List<PluginInfo> plugins = new List<PluginInfo>();
        string[] filePaths = Directory.GetFiles("Plugins");
        foreach (string filePath in filePaths)
        {
            Assembly assembly = Assembly.LoadFrom(filePath);
            _pluginCollection.Add(new PluginInfo { Assembly = assembly });
        }
    }

    public List<PluginInfo> GetList()
    {
        return _pluginCollection;
    }
}
