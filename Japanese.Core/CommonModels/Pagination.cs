using Japanese.Core.Encoding;

namespace Japanese.Core.CommonModels;

public class Pagination
{
    private Base64 _base64;
    private string? _paginationToken;

    public Pagination() { _base64 = new Base64(); }

    public string? PaginationToken { 
        get { return _base64.Encode(_paginationToken); } 
        set { _paginationToken = (_base64.IsBase64String(value))? _base64.Decode(value) : value; } 
    }

    public int PageSize { get; set; }
    public string? SearchBy { get; set; }
    public string? Keyword { get; set; }
}