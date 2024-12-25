using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MediatR;

namespace Japanese.Services.Kana.Commands.DeleteKana;

public class DeleteKanaHandler : IRequestHandler<DeleteKanaCommand, ExecResult>
{
    private readonly IKanaRepository _kanaRepository;

    public DeleteKanaHandler(IJapaneseRepository repository)
    {
        _kanaRepository = repository.KanaRepository;
    }

    public async Task<ExecResult> Handle(DeleteKanaCommand request, CancellationToken cancellationToken)
    {
        await _kanaRepository.DeleteAsync(f => f.Character == request.Character, request.ForceDelete);
        return new ExecResult { Status = ExecStatus.Success };
    }
}
