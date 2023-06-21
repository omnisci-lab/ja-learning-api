using Japanese.Domain.Common;
using MediatR;

namespace Japanese.Application.Features.CommonWord.Commands.BatchDeleteCommonWord;

public class BatchDeleteCommonWordCommand : IRequest<ExecResult>
{
    public string? WordId { get; set; }
}
