using MediatR;

namespace Japanese.Application.Features.Kanji.Queries.GetKanji;

public class GetKanjiQuery : IRequest<KanjiDetailOutput>
{
    public string? KanjiId { get; set; }
}
