using Japanese.Application.Contracts.Presistence;
using Japanese.Domain.Common;
using MediatR;

using CommonWordEntity = Japanese.Domain.Entities.CommonWordGroup.CommonWord;

namespace Japanese.Application.Features.CommonWord.Commands.UpdateCommonWord;

public class UpdateCommonWordCommandHandler : IRequestHandler<UpdateCommonWordCommand, ExecResult>
{
    private ICommonWordRepository _commonWordRepository;

    public UpdateCommonWordCommandHandler(IJapaneseRepository japaneseRepository)
    {
        _commonWordRepository = japaneseRepository.CommonWordRepository;
    }

    public async Task<ExecResult> Handle(UpdateCommonWordCommand request, CancellationToken cancellationToken)
    {
        return await _commonWordRepository.UpdateAsync(new[] { request.WordId }, request, Map);
    }

    private void Map(UpdateCommonWordCommand input,  CommonWordEntity entity)
    {
        entity.Id = input.WordId;
        entity.Word = input.Word;
        entity.Kana = input.Kana;
        entity.Romaji = input.Romaji;
    }
}
