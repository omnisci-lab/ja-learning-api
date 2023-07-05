using Microsoft.AspNetCore.Routing;
using System.Reflection;
using WebCore.DynamicTable;

namespace WebCore.Extensions;

public static class RouteValueDictionaryExtensions
{
    public static void From(this RouteValueDictionary routeValueDict, List<RouteValueObject> routeValues, DynamicTableRow row)
    {
        foreach (RouteValueObject? routeValueObject in routeValues)
        {
            object? value = row.Columns!.SingleOrDefault(x => x.Name == routeValueObject.MapToProperty)?.Value;
            routeValueDict.Add(routeValueObject.RouteProperty!, value);
        }
    }

    public static void From(this RouteValueDictionary routeValueDict, List<RouteValueObject> routeValues, Type type, object data)
    {
        foreach (RouteValueObject? routeValueObject in routeValues)
        {
            PropertyInfo? property = type.GetProperty(routeValueObject.MapToProperty!);
            object? propertyValue = (property is null) ? null : property.GetValue(data);

            routeValueDict.Add(routeValueObject.RouteProperty!, propertyValue);
        }
    }
}
