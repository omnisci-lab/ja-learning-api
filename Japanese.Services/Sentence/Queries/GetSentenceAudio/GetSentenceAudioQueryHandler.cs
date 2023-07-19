using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.LanguageCore.AWS;
using Japanese.LanguageCore.SynthesizeSpeech;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MediatR;

namespace Japanese.Services.Sentence.Queries.GetSentenceAudio;

public class GetSentenceAudioQueryHandler : IRequestHandler<GetSentenceAudioQuery, ExecResult<byte[]>>
{
    private readonly ISentenceRepository _sentenceRepository;
    private readonly PollyService _pollyService;
    private readonly SimpleStorageService _simpleStorageService;

    public GetSentenceAudioQueryHandler(IJapaneseRepository japaneseRepository, PollyService pollyService, SimpleStorageService simpleStorageService)
    {
        _sentenceRepository = japaneseRepository.SentenceRepository;
        _pollyService = pollyService;
        _simpleStorageService = simpleStorageService;
    }

    public async Task<ExecResult<byte[]>> Handle(GetSentenceAudioQuery request, CancellationToken cancellationToken)
    {
        SentenceModel? sentenceModel = await _sentenceRepository.GetAsync(request.SentenceId);
        if (sentenceModel is null)
            return new ExecResult<byte[]> { Status = ExecStatus.NotFound };

        using Stream? stream = await _simpleStorageService.GetFile("files.japanese", $"sentence_audios/{sentenceModel.SentenceId}.mp3");
        if (stream is not null)
        {
            using MemoryStream memoryStream = new MemoryStream();
            await stream.CopyToAsync(memoryStream);

            return new ExecResult<byte[]>
            {
                Status = ExecStatus.Success,
                Data = memoryStream.ToArray()
            };
        }

        using MemoryStream memoryStreamFromSynthesis = await _pollyService.SynthesizeSpeech(sentenceModel.Text!);
        await _simpleStorageService.UploadFile("files.japanese", $"sentence_audios/{sentenceModel.SentenceId}.mp3", memoryStreamFromSynthesis);

        return new ExecResult<byte[]>
        {
            Status = ExecStatus.Success,
            Data = memoryStreamFromSynthesis.ToArray()
        };
    }
}
