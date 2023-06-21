using Japanese.Domain.Common;
using MediatR;

namespace Japanese.Application.Features.CommonWord.Commands.CreateCommonWord;

public class CreateCommonWordCommand : IRequest<ExecResult>
{
    public string? Word { get; set; }
    public string? Kana { get; set; }
    public string? Romaji { get; set; }
}