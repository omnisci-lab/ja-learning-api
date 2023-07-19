using Japanese.Core.CommonModels;
using Japanese.Services.Sentence.Queries.GetSentence;
using MediatR;

namespace Japanese.Services.Sentence.Queries.GetSentenceAudio;

public class GetSentenceAudioQueryHandler : IRequestHandler<GetSentenceQuery, ExecResult<SentenceOutput?>>
{
    public Task<ExecResult<SentenceOutput?>> Handle(GetSentenceQuery request, CancellationToken cancellationToken)
    {
        return null;
    }
}
