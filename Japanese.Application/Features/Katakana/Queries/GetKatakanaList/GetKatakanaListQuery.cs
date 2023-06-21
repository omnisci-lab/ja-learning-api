using MediatR;

namespace Japanese.Application.Features.Katakana.Queries.GetKatakanaList;

public class GetKatakanaListQuery : IRequest<List<KatakanaOutput>>
{
}
