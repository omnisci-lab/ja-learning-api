using System.Reflection;

namespace Japanese.Core.ExtensionMethods;

public static class AssemblyExtensions
{
    public static Type[] GetTypesInNamespace(string targetNamespace)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        Type[] types = assembly.GetTypes();

        Type[] matchingTypes = Array.FindAll(types, type => type.Namespace == targetNamespace);

        return matchingTypes;
    }
}
