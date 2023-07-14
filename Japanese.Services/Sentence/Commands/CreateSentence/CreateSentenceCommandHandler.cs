using AutoMapper;
using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MediatR;

namespace Japanese.Services.Sentence.Commands.CreateSentence;

public class CreateSentenceCommandHandler : IRequestHandler<CreateSentenceCommand, ExecResult>
{
    private readonly ISentenceRepository _sentenceRepository;
    private readonly IMapper _mapper;

    public CreateSentenceCommandHandler(IJapaneseRepository japaneseRepository, IMapper mapper)
    {
        _sentenceRepository = japaneseRepository.SentenceRepository;
        _mapper = mapper;
    }

    public async Task<ExecResult> Handle(CreateSentenceCommand request, CancellationToken cancellationToken)
    {
        SentenceModel sentenceModel = _mapper.Map<CreateSentenceCommand, SentenceModel>(request);

        sentenceModel.SentenceId = Guid.NewGuid().ToString();
        sentenceModel.CreatedDate = DateTime.Now;

        await _sentenceRepository.SaveItemAsync(sentenceModel);

        return new ExecResult { Status = ExecStatus.Success };
    }
}