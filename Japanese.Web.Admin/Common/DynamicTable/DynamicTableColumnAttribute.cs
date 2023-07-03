namespace Japanese.Web.Admin.Common.DynamicTable;

[AttributeUsage(AttributeTargets.Property)]
public class DynamicTableColumnAttribute : Attribute
{
    public string? DisplayName { get; set; }
}
