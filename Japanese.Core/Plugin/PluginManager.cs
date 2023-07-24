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

        string pluginFolderPath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)!, "plugins");
        string[] subPluginFolderPaths = Directory.GetDirectories(pluginFolderPath);
        
        foreach(string subPluginFolderPath in subPluginFolderPaths)
        {
            string[] filePaths = Directory.GetFiles(subPluginFolderPath)
                .Where(x => Path.GetExtension(x) == ".dll").ToArray();

            foreach(string filePath in filePaths)
            {
                Assembly assembly = Assembly.LoadFrom(filePath);
                if (assembly.GetTypes().Any(x => x.Name == "PluginExecution"))
                    _pluginCollection.Add(new PluginInfo { Assembly = assembly });
            }
        }
    }

    public List<PluginInfo> GetList()
    {
        if (_pluginCollection.Count == 0)
            Load();

        return _pluginCollection;
    }

    public void ExecutePlugins(object? request, object? response)
    {
        if (_pluginCollection.Count == 0)
            Load();

        foreach (PluginInfo plugin in _pluginCollection)
        {
            plugin.Execute(request, response);
        }
    }
}
