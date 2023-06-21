using MediatR;

namespace Japanese.Application.Sentence.Queries.GetSentence;

public class GetSentenceQuery : IRequest<SentenceOutput>
{
    public string? SentenceId { get; set; }
}
