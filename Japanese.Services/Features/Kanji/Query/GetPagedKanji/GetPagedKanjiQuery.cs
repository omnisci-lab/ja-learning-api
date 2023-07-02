using Japanese.Core.CommonModels;
using Japanese.Services.Features.Kanji.Queries.GetKanji;
using MediatR;

namespace Japanese.Services.Features.Kanji.Query.GetPagedKanji;

public class GetPagedKanjiQuery : Pagination, IRequest<Pagination<KanjiDetailOutput>>
{

}
