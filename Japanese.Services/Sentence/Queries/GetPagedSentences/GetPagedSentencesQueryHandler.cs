using AutoMapper;
using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using Japanese.Services.Sentence.Consts;
using MediatR;

namespace Japanese.Services.Sentence.Queries.GetPagedSentences;

public class GetPagedSentencesQueryHandler : IRequestHandler<GetPagedSentencesQuery, ExecResult<PagedResult<SentenceOutput>>>
{
    //private readonly ISentenceRepository _sentenceRepository;
    private readonly IMapper _mapper;

    public GetPagedSentencesQueryHandler(IJapaneseRepository repository, IMapper mapper)
    {
        //_sentenceRepository = repository.SentenceRepository;
        _mapper = mapper;
    }

    public async Task<ExecResult<PagedResult<SentenceOutput>>> Handle(GetPagedSentencesQuery request, CancellationToken cancellationToken)
    {
        PagedResult<SentenceModel>? paged_raw = null;

        //if (string.IsNullOrEmpty(request.Keyword))
        //    paged_raw = await _sentenceRepository.GetPagedAsync(request);
        //else if (request.FilterBy == SentenceConsts.ByText)
        //    paged_raw = await _sentenceRepository.SearchByTextAsync(request);
        //else if (request.FilterBy == SentenceConsts.ByViMeaning)
        //    paged_raw = await _sentenceRepository.SearchByViMeaningAsync(request);
        //else
        //    paged_raw = await _sentenceRepository.GetPagedAsync(request);

        return new ExecResult<PagedResult<SentenceOutput>>
        {
            Status = ExecStatus.Success,
            Data = _mapper.Map<PagedResult<SentenceModel>, PagedResult<SentenceOutput>>(paged_raw)
        };
    }
}