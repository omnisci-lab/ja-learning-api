using AutoMapper;
using Japanese.Core.CommonModels;
using Japanese.Models;
using Japanese.Services.Kanji.Queries;

namespace Japanese.Services.Kanji.Mappings;

public class P_Kanken_KanjiDetail_Converter : ITypeConverter<PagedResult<KankenModel>, PagedResult<KanjiDetailOutput>>
{
    public PagedResult<KanjiDetailOutput> Convert(PagedResult<KankenModel> source, PagedResult<KanjiDetailOutput> destination, ResolutionContext context)
    {
        if (destination is null)
            destination = new PagedResult<KanjiDetailOutput>();

        destination.PageSize = source.PageSize;
        destination.PaginationToken = source.PaginationToken;
        destination.SearchBy = source.SearchBy;
        destination.Keyword = source.Keyword;

        return destination;
    }
}