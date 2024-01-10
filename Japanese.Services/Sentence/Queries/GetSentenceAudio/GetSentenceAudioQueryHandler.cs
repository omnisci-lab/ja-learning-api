using Japanese.Core.AWS;
using Japanese.Core.AWS.Helpers;
using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MediatR;

namespace Japanese.Services.Sentence.Queries.GetSentenceAudio;

public class GetSentenceAudioQueryHandler : IRequestHandler<GetSentenceAudioQuery, FileResult>
{
    private readonly ISentenceRepository _sentenceRepository;
    private readonly PollyHelper _pollyHelper;
    private readonly S3Helper _s3Helper;

    public GetSentenceAudioQueryHandler(IJapaneseRepository japaneseRepository, IAwsService awsService)
    {
        _sentenceRepository = japaneseRepository.SentenceRepository;
        _pollyHelper = awsService.CreatePollyHelper();
        _s3Helper = awsService.CreateS3Helper();
    }

    public async Task<FileResult> Handle(GetSentenceAudioQuery request, CancellationToken cancellationToken)
    {
        SentenceModel? sentenceModel = await _sentenceRepository.GetAsync(request.SentenceId);
        if (sentenceModel is null)
            return new FileResult { Status = ExecStatus.NotFound };

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

            return new FileResult
            {
                Status = ExecStatus.Success,
                ContentType = "audio/mpeg",
                Data = await GenerateAndUploadVoice(sentenceModel.Text!, voiceSoundKeyName, request.VoiceOptions)
            };
        }

        using Stream? stream = await _s3Helper.GetFile("files.japanese", voiceSoundKeyName);
        if (stream is null)
            return new FileResult
            {
                Status = ExecStatus.Success,
                ContentType = "audio/mpeg",
                Data = await GenerateAndUploadVoice(sentenceModel.Text!, voiceSoundKeyName, request.VoiceOptions)
            };

        using MemoryStream memoryStream = new MemoryStream();
        await stream.CopyToAsync(memoryStream);

        return new FileResult
        {
            Status = ExecStatus.Success,
            ContentType = "audio/mpeg",
            Data = memoryStream.ToArray()
        };
    }

    private async Task<byte[]> GenerateAndUploadVoice(string text, string voiceSoundKeyName, VoiceOptions voiceOptions)
    {
        using MemoryStream memoryStreamFromSynthesis = await _pollyHelper.BasicSynthesizeSpeech(text, voiceOptions);
        await _s3Helper.UploadFile("files.japanese", voiceSoundKeyName, memoryStreamFromSynthesis);

        return memoryStreamFromSynthesis.ToArray();
    }
}