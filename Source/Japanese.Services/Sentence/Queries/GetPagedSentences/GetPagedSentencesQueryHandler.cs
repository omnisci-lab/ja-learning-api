using AutoMapper;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using khothemegiatot.WebApi.Enums;
using khothemegiatot.WebApi.Models;
using MediatR;

namespace Japanese.Services.Sentence.Queries.GetPagedSentences;

public class GetPagedSentencesQueryHandler : IRequestHandler<GetPagedSentencesQuery, ExecResult<PagedResult<SentenceOutput>>>
{
    private readonly ISentenceRepository _sentenceRepository;
    private readonly IMapper _mapper;

    public GetPagedSentencesQueryHandler(IJapaneseRepository repository, IMapper mapper)
    {
        _sentenceRepository = repository.SentenceRepository;
        _mapper = mapper;
    }

    public async Task<ExecResult<PagedResult<SentenceOutput>>> Handle(GetPagedSentencesQuery request, CancellationToken cancellationToken)
    {
        PagedResult<SentenceModel> pagedRaw = await _sentenceRepository.GetPaginatedAsync(request);

        PagedResult<SentenceOutput> pagedResult = pagedRaw
            .CreatePagedResult(_mapper.Map<List<SentenceModel>, List<SentenceOutput>>(pagedRaw.Items));

        return new ExecResult<PagedResult<SentenceOutput>>
        {
            Status = ExecStatus.Success,
            Data = pagedResult
        };
    }
}