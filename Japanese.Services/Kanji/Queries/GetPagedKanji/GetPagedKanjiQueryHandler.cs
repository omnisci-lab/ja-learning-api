using AutoMapper;
using Japanese.Core.CommonModels;
using Japanese.Core.Encoding;
using Japanese.Core.Enum;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MediatR;
using Nest;

namespace Japanese.Services.Kanji.Queries.GetPagedKanji;

public class GetPagedKanjiQueryHandler : IRequestHandler<GetPagedKanjiQuery, ExecResult<PagedResult<KanjiDetailOutput>>>
{
    private readonly IKanjidic2Repository _kanjidic2Repository;
    private readonly IKanjidic2ExtensionRepository _kanjidic2ExtensionRepository;
    private readonly IMapper _mapper;
    private readonly IElasticClient _elasticClient;
    private Base64 _base64;

    public GetPagedKanjiQueryHandler(IJapaneseRepository repository, IMapper mapper, IElasticClient elasticClient)
    {
        _kanjidic2Repository = repository.Kanjidic2Repository;
        _kanjidic2ExtensionRepository = repository.Kanjidic2ExtensionRepository;
        _mapper = mapper;
        _elasticClient = elasticClient;
        _base64 = new Base64();
    }

    public async Task<ExecResult<PagedResult<KanjiDetailOutput>>> Handle(GetPagedKanjiQuery request, CancellationToken cancellationToken)
    {
        ISearchResponse<Kanjidic2ExtensionModel> searchResponse =  await _elasticClient.SearchAsync<Kanjidic2ExtensionModel>(s =>s
            .From((request.Page - 1) * request.PageSize)
            .Size(request.PageSize)
            .Query(q => q.Match(m => m
                .Field(f => f.Literal).Query(request.Keyword))
            ));

        if (!searchResponse.IsValid)
            return new ExecResult<PagedResult<KanjiDetailOutput>> { Status = ExecStatus.Invalid };

        PagedResult<KanjiDetailOutput>? paged = new PagedResult<KanjiDetailOutput>();
        paged.PageSize = request.PageSize;
        paged.Keyword = request.Keyword;

        foreach(IHit<Kanjidic2ExtensionModel> hit in searchResponse.Hits)
        {
            Kanjidic2ExtensionModel kanjidic2ExtensionModel = hit.Source;
            KanjiDetailOutput kanjiDetailOutput = _mapper.Map<Kanjidic2ExtensionModel, KanjiDetailOutput>(kanjidic2ExtensionModel);
            paged.Items.Add(kanjiDetailOutput);
        }

        return new ExecResult<PagedResult<KanjiDetailOutput>>
        {
            Status = ExecStatus.Success,
            Data = paged
        };
    }
}