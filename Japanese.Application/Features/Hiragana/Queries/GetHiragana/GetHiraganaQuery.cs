using MediatR;

namespace Japanese.Application.Features.Hiragana.Queries.GetHiragana;

public class GetHiraganaQuery : IRequest<HiraganaOutput>
{
    public string? HiraganaId { get; set; }
}
