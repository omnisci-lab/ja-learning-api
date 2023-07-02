using Japanese.Services.Cache;
using MediatR;

namespace Japanese.Services.Features.Sentence.Queries.SearchSentences;

public class SearchSentencesQuery : IRequest<List<SentenceOutput>>, ICacheableQuery
{
    public string? Keyword { get; set; }

    public string? CacheKey => $"seach_sentences_k_{Keyword}";

    public bool Bypass { get; set; }
    public bool RefreshCache { get; set; }
}