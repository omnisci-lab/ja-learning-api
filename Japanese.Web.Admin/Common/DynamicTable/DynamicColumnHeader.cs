namespace Japanese.Web.Admin.Common.DynamicTable;

public class DynamicColumnHeader
{
    public string? OriginName { get; set; }
    public string? CustomName { get; set; }

    public string? DisplayName { get => string.IsNullOrEmpty(CustomName) ? OriginName : CustomName; }
}