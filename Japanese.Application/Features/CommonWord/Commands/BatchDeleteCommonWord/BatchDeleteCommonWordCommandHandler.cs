using Japanese.Application.Contracts.Presistence;
using Japanese.Domain.Common;
using MediatR;

namespace Japanese.Application.Features.CommonWord.Commands.BatchDeleteCommonWord;

public class BatchDeleteCommonWordCommandHandler : IRequestHandler<BatchDeleteCommonWordCommand, ExecResult>
{
    private ICommonWordRepository _commonWordRepository;

    public BatchDeleteCommonWordCommandHandler(IJapaneseRepository repository)
    {
        _commonWordRepository = repository.CommonWordRepository;
    }

    public async Task<ExecResult> Handle(BatchDeleteCommonWordCommand request, CancellationToken cancellationToken)
    {
        return await _commonWordRepository.BatchDeleteAsync(request.WordId, cancellationToken);
    }
}