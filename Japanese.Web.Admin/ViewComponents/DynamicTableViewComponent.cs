using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using WebCore;
using WebCore.Attributes;
using WebCore.DynamicTable;
using WebCore.Extensions;

namespace Japanese.Web.Admin.ViewComponents;

[ViewComponent(Name = "DynamicTable")]
public class DynamicTableViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(Type type, Type metadataType, object[] data, UrlInfo detailUrl)
    {
        DynamicTable dynamicTable = new DynamicTable();

        dynamicTable.ColumnHeaders.AddRange(metadataType.GetProperties()
            .Where(x =>
            {
                DynamicViewAttribute? dynamicViewAttribute = x.GetCustomAttribute<DynamicViewAttribute>();
                if (dynamicViewAttribute is null)
                    return false;

                if (dynamicViewAttribute.Table)
                    return true;

                return false;
            }).Select(s =>
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
            DynamicTableRow row = new DynamicTableRow { Columns = columns };

            routeValueDict.From(detailUrl.RouteValues, row);
            columns.Add(new DynamicTableColumn { Name = "DetailURL", Value = Url.Action(detailUrl.ActionName, detailUrl.ControllerName, routeValueDict) });
            
            dynamicTable.Rows.Add(row);
        }

        return View(dynamicTable);
    }
}
