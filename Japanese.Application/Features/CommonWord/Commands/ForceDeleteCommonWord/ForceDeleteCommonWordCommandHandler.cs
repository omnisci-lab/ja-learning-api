using Japanese.Application.Contracts.Presistence;
using Japanese.Domain.Common;
using MediatR;

namespace Japanese.Application.Features.CommonWord.Commands.ForceDeleteCommonWord;

public class ForceDeleteCommonWordCommandHandler : IRequestHandler<ForceDeleteCommonWordCommand, ExecResult>
{
    private ICommonWordRepository _commonWordRepository;

    public ForceDeleteCommonWordCommandHandler(IJapaneseRepository japaneseRepository)
    {
        _commonWordRepository = japaneseRepository.CommonWordRepository;
    }

    public async Task<ExecResult> Handle(ForceDeleteCommonWordCommand request, CancellationToken cancellationToken)
    {
        return await _commonWordRepository.ForceDeleteAsync(request.WordId);
    }
}
