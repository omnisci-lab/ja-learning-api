using Japanese.Core.CommonModels;
using Japanese.Services.Kanji.Queries.GetKanji;
using MediatR;

namespace Japanese.Services.Kanji.Queries.GetPagedKanji;

public class GetPagedKanjiQuery : Pagination, IRequest<Pagination<KanjiDetailOutput>>
{

}
