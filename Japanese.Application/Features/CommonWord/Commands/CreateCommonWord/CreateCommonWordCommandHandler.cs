using Japanese.Application.Contracts.Presistence;
using Japanese.Domain.Common;
using MediatR;
using shortid;
using CommonWordEntity = Japanese.Domain.Entities.CommonWordGroup.CommonWord;

namespace Japanese.Application.Features.CommonWord.Commands.CreateCommonWord;

public class CreateCommonWordCommandHandler : IRequestHandler<CreateCommonWordCommand, ExecResult>
{
    private ICommonWordRepository _commonWordRepository;

    public CreateCommonWordCommandHandler(IJapaneseRepository japaneseRepository)
    {
        _commonWordRepository = japaneseRepository.CommonWordRepository;
    }

    public async Task<ExecResult> Handle(CreateCommonWordCommand request, CancellationToken cancellationToken)
    {
        return await _commonWordRepository.AddAsync(request, Map);
    }

    public void Map(CreateCommonWordCommand input, CommonWordEntity entity)
    {
        entity.Id = ShortId.Generate();
        entity.Word = input.Word;
        entity.Kana = input.Kana;
        entity.Romaji = input.Romaji;
    }
}