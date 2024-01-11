using Japanese.Core.CommonModels;
using Japanese.Services.Cache;
using MediatR;

namespace Japanese.Services.Kanji.Queries.GetPagedKanji;

public class GetPagedKanjiQuery : Pagination, IRequest<ExecResult<PagedResult<KanjiDetailOutput>>>
{

}