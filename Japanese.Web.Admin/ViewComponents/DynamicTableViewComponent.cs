using Japanese.Web.Admin.Common;
using Japanese.Web.Admin.Common.DynamicTable;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Japanese.Web.Admin.ViewComponents;

[ViewComponent(Name = "DynamicTable")]
public class DynamicTableViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(Type type, Type metadataType, object[] data, UrlInfo detailUrl)
    {
        DynamicTable dynamicTable = new DynamicTable();

        dynamicTable.ColumnHeaders.AddRange(metadataType
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

        PropertyInfo[] tableProperties = type.GetProperties()
            .Where(x => dynamicTable.ColumnHeaders.Any(h => h.OriginName == x.Name)).ToArray();

        foreach(object item in data)
        {
            List<DynamicTableColumn> columns = tableProperties.Select(s => new DynamicTableColumn { 
                Name = s.Name, Value = s.GetValue(item)
            }).ToList();

            RouteValueDictionary routeValueDict = new RouteValueDictionary();
            foreach (RouteValueObject routeValueObject in detailUrl.RouteValues!)
            {
                object? value = columns.SingleOrDefault(x => x.Name == routeValueObject.MapToProperty)?.Value;
                routeValueDict.Add(routeValueObject.RouteProperty!, value);
            }

            columns.Add(new DynamicTableColumn { Name = "DetailURL", Value = Url.Action(detailUrl.ActionName, detailUrl.ControllerName, routeValueDict) });

            dynamicTable.Rows.Add(new DynamicTableRow { Columns = columns });
        }

        return View(dynamicTable);
    }
}
