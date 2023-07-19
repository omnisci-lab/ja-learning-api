using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.LanguageCore.SynthesizeSpeech;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MediatR;

namespace Japanese.Services.Sentence.Queries.GetSentenceAudio;

public class GetSentenceAudioQueryHandler : IRequestHandler<GetSentenceAudioQuery, ExecResult<MemoryStream>>
{
    private readonly ISentenceRepository _sentenceRepository;
    private readonly PollyService _pollyService;

    public GetSentenceAudioQueryHandler(IJapaneseRepository japaneseRepository, PollyService pollyService)
    {
        _sentenceRepository = japaneseRepository.SentenceRepository;
        _pollyService = pollyService;
    }

    public async Task<ExecResult<MemoryStream>> Handle(GetSentenceAudioQuery request, CancellationToken cancellationToken)
    {
        SentenceModel? sentenceModel = await _sentenceRepository.GetAsync(request.SentenceId);
        if (sentenceModel is null)
            return new ExecResult<MemoryStream> { Status = ExecStatus.NotFound };

        MemoryStream memoryStream = await _pollyService.SynthesizeSpeech(sentenceModel.Text!);

        return new ExecResult<MemoryStream> { Status = ExecStatus.Success, Data = memoryStream };
    }
}
