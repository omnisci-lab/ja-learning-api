using MediatR;

namespace Japanese.Application.Features.Katakana.Queries.GetKatakana;

public class GetKatakanaQuery : IRequest<KatakanaOutput>
{
    public string? KatakanaId { get; set; }
}
