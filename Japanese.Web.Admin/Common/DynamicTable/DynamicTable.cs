namespace Japanese.Web.Admin.Common.DynamicTable;

public class DynamicTable
{
    public List<DynamicColumnHeader> ColumnHeaders { get; set; } = new List<DynamicColumnHeader>();
    public List<DynamicTableRow> Rows { get; set; } = new List<DynamicTableRow>();
}
