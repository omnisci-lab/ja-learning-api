using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.LanguageCore.AWS;
using Japanese.LanguageCore.Enum;
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

        string? voiceSoundKeyName;
        if (request.VoiceOptions == VoiceOptions.MaleVoiceSound)
            voiceSoundKeyName = sentenceModel.MaleVoiceSound;
        else
            voiceSoundKeyName = sentenceModel.FemaleVoiceSound;

        if (string.IsNullOrEmpty(voiceSoundKeyName))
        {
            if (request.VoiceOptions == VoiceOptions.MaleVoiceSound)
            {
                voiceSoundKeyName = $"sentence_audios/{sentenceModel.SentenceId}_male-voice-sound.mp3";
                sentenceModel.MaleVoiceSound = voiceSoundKeyName;
            }
            else
            {
                voiceSoundKeyName = $"sentence_audios/{sentenceModel.SentenceId}_female-voice-sound.mp3";
                sentenceModel.FemaleVoiceSound = voiceSoundKeyName;
            }

            await _sentenceRepository.SaveAsync(sentenceModel);

            return new ExecResult<byte[]>
            {
                Status = ExecStatus.Success,
                Data = await GenerateAndUploadVoice(sentenceModel.Text!, voiceSoundKeyName, request.VoiceOptions)
            };
        }

        using Stream? stream = await _simpleStorageService.GetFile("files.japanese", voiceSoundKeyName);
        if (stream is null)
            return new ExecResult<byte[]>
            {
                Status = ExecStatus.Success,
                Data = await GenerateAndUploadVoice(sentenceModel.Text!, voiceSoundKeyName, request.VoiceOptions)
            };

        using MemoryStream memoryStream = new MemoryStream();
        await stream.CopyToAsync(memoryStream);

        return new ExecResult<byte[]>
        {
            Status = ExecStatus.Success,
            Data = memoryStream.ToArray()
        };
    }

    private async Task<byte[]> GenerateAndUploadVoice(string text, string voiceSoundKeyName, VoiceOptions voiceOptions)
    {
        using MemoryStream memoryStreamFromSynthesis = await _pollyService.BasicSynthesizeSpeech(text, voiceOptions);
        await _simpleStorageService.UploadFile("files.japanese", voiceSoundKeyName, memoryStreamFromSynthesis);

        return memoryStreamFromSynthesis.ToArray();
    }
}