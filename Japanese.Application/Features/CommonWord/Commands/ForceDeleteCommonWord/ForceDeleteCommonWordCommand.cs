using Japanese.Domain.Common;
using MediatR;

namespace Japanese.Application.Features.CommonWord.Commands.ForceDeleteCommonWord;

public class ForceDeleteCommonWordCommand : IRequest<ExecResult>
{
    public string? WordId { get; set; }
}