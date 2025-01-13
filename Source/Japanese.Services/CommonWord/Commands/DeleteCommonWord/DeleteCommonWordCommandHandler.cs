using Japanese.Repositories.Interfaces;
using khothemegiatot.WebApi.Enums;
using khothemegiatot.WebApi.Models;
using MediatR;
using MongoDB.Bson;

namespace Japanese.Services.CommonWord.Commands.DeleteCommonWord;

public class DeleteCommonWordCommandHandler : IRequestHandler<DeleteCommonWordCommand, ExecResult>
{
    private readonly ICommonWordRepository _commonWordRepository;

    public DeleteCommonWordCommandHandler(IJapaneseRepository repository)
    {
        _commonWordRepository = repository.CommonWordRepository;
    }

    public async Task<ExecResult> Handle(DeleteCommonWordCommand request, CancellationToken cancellationToken)
    {
        await _commonWordRepository.DeleteAsync(x => x.Id == ObjectId.Parse(request.WordId), request.ForceDelete);
        return new ExecResult { Status = ExecStatus.Success };
    }
}
