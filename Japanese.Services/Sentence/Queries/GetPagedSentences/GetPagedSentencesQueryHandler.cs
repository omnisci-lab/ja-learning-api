using AutoMapper;
using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MediatR;

namespace Japanese.Services.Sentence.Queries.GetPagedSentences;

public class GetPagedSentencesQueryHandler : IRequestHandler<GetPagedSentencesQuery, ExecResult<Pagination<SentenceOutput>>>
{
    private readonly ISentenceRepository _sentenceRepository;
    private readonly IMapper _mapper;

    public GetPagedSentencesQueryHandler(IJapaneseRepository repository, IMapper mapper)
    {
        _sentenceRepository = repository.SentenceRepository;
        _mapper = mapper;
    }

    public async Task<ExecResult<Pagination<SentenceOutput>>> Handle(GetPagedSentencesQuery request, CancellationToken cancellationToken)
    {
        Pagination<SentenceModel> paged_raw = await _sentenceRepository.GetPagedAsync(request);

        return new ExecResult<Pagination<SentenceOutput>>
        {
            Status = ExecStatus.Success,
            Data = _mapper.Map<Pagination<SentenceModel>, Pagination<SentenceOutput>>(paged_raw)
        };
    }
}