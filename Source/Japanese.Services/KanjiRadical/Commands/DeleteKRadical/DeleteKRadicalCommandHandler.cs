using AutoMapper;
using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.Repositories.Interfaces;
using khothemegiatot.WebApi.Enums;
using khothemegiatot.WebApi.Models;
using MediatR;

namespace Japanese.Services.KanjiRadical.Commands.DeleteKRadical;

public class DeleteKRadicalCommandHandler : IRequestHandler<DeleteKRadicalCommand, ExecResult>
{
    private readonly IKanjiRadicalRepository _kanjiRadicalRepository;
    private readonly IMapper _mapper;

    public DeleteKRadicalCommandHandler(IJapaneseRepository repository, IMapper mapper)
    {
        _kanjiRadicalRepository = repository.KanjiRadicalRepository;
        _mapper = mapper;
    }

    public async Task<ExecResult> Handle(DeleteKRadicalCommand request, CancellationToken cancellationToken)
    {
        await _kanjiRadicalRepository.DeleteAsync(f => f.Character == request.Character, request.ForceDelete);
        return new ExecResult { Status = ExecStatus.Success };
    }
}
