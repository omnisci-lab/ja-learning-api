using AutoMapper;
using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MediatR;

namespace Japanese.Services.Sentence.Commands.UpdateSentence;

public class UpdateSentenceCommandHandler : IRequestHandler<UpdateSentenceCommand, ExecResult>
{
    private readonly ISentenceRepository _sentenceRepository;
    private readonly IMapper _mapper;

    public UpdateSentenceCommandHandler(IJapaneseRepository japaneseRepository, IMapper mapper)
    {
        _sentenceRepository = japaneseRepository.SentenceRepository;
        _mapper = mapper;
    }

    public async Task<ExecResult> Handle(UpdateSentenceCommand request, CancellationToken cancellationToken)
    {
        SentenceModel? sentenceModel = await _sentenceRepository.GetAsync(request.SentenceId);
        if (sentenceModel is null)
            return new ExecResult { Status = ExecStatus.NotFound };

        _mapper.Map(request, sentenceModel);

        sentenceModel.LastModifiedDate = DateTime.Now;
        await _sentenceRepository.SaveAsync(sentenceModel);

        return new ExecResult { Status = ExecStatus.Success };
    }
}
