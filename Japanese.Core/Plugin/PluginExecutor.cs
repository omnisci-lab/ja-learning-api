using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Japanese.Core.Plugin;

public class PluginExecutor
{
    private readonly PluginInfo _plugin;

    public PluginExecutor(PluginInfo plugin) { }

    private void LoadAssembly()
    {
        //Assembly assembly = Assembly.LoadFrom(filePath);
    }

    public void ExecuteBefore()
    {

    }

    public void ExecuteAfter()
    {

    }
}
