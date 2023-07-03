using Japanese.Web.Admin.Common.DynamicTable;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Japanese.Web.Admin.ViewComponents;

[ViewComponent(Name = "DynamicTable")]
public class DynamicTableViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(Type headerType, Type bodyType, object[] data, string actionName, Dictionary<string, string> routeKeys)
    {
        DynamicTable dynamicTable = new DynamicTable();

        dynamicTable.ColumnHeaders.AddRange(headerType
            .GetProperties().Where(x => x.GetCustomAttribute<DynamicTableColumnAttribute>() is not null)
            .Select(s =>
            {
                DynamicColumnHeader columnHeader = new DynamicColumnHeader
                {
                    OriginName = s.Name
                };

                DisplayAttribute? displayAttribute = s.GetCustomAttribute<DisplayAttribute>();
                if (displayAttribute is not null)
                    columnHeader.CustomName = displayAttribute.Name;

                return columnHeader;
            }).ToList());

        PropertyInfo[] tableProperties = bodyType.GetProperties()
            .Where(x => dynamicTable.ColumnHeaders.Any(h => h.OriginName == x.Name)).ToArray();

        foreach(object item in data)
        {
            List<DynamicTableColumn> columns = tableProperties.Select(s => new DynamicTableColumn { 
                Name = s.Name, Value = s.GetValue(item)
            }).ToList();

            Dictionary<string, object> routeValues = new Dictionary<string, object>();
            foreach(KeyValuePair<string, string> routeKey in routeKeys)
            {
                routeValues.Add(routeKey.Value, columns.SingleOrDefault(x => x.Name == routeKey.Key)!.Value!);
            }

            columns.Add(new DynamicTableColumn { Name = "DetailURL", Value = Url.Action(actionName, routeValues) });

            dynamicTable.Rows.Add(new DynamicTableRow { Columns = columns });
        }

        return View(dynamicTable);
    }
}
