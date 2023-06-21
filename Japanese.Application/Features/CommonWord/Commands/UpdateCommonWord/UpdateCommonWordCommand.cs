using Japanese.Domain.Common;
using MediatR;

namespace Japanese.Application.Features.CommonWord.Commands.UpdateCommonWord;

public class UpdateCommonWordCommand : IRequest<ExecResult>
{
    public string? WordId { get; set; }
    public string? Word { get; set; }
    public string? Kana { get; set; }
    public string? Romaji { get; set; }
}
