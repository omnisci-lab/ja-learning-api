using AutoMapper;
using Japanese.CachedRepository.Interfaces;
using Japanese.Core.CommonModels;
using Japanese.Core.Encoding;
using Japanese.Core.Enum;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using Japanese.Services.Kanji.Consts;
using MediatR;

namespace Japanese.Services.Kanji.Queries.GetPagedKanji;

public class GetPagedKanjiQueryHandler : IRequestHandler<GetPagedKanjiQuery, ExecResult<PagedResult<KanjiDetailOutput>>>
{
    private readonly IKanjidic2Repository _kanjidic2Repository;
    private readonly IKanjidic2ExtensionRepository _kanjidic2ExtensionRepository;
    private readonly IMapper _mapper;
    private Base64 _base64;

    public GetPagedKanjiQueryHandler(IJapaneseRepository repository, IJapaneseCachedRepository cachedRepository, IMapper mapper)
    {
        _kanjidic2Repository = repository.Kanjidic2Repository;
        _kanjidic2ExtensionRepository = repository.Kanjidic2ExtensionRepository;
        _mapper = mapper;
        _base64 = new Base64();
    }

    public async Task<ExecResult<PagedResult<KanjiDetailOutput>>> Handle(GetPagedKanjiQuery request, CancellationToken cancellationToken)
    {
        PagedResult<Kanjidic2Model> pagedResultRaw = null!;
        if (request.FilterBy == KanjiFilterConsts.All)
        {
            pagedResultRaw = await _kanjidic2Repository.GetPaginatedAsync(request);

            List<string?> literals = pagedResultRaw.Items.Select(s => s.Literal).ToList();
            List<Kanjidic2ExtensionModel> kanjidic2ExtensionModels = await _kanjidic2ExtensionRepository
                .GetItemsByLiteralsAsync(literals);

            foreach (Kanjidic2Model kanjidic2Model in pagedResultRaw.Items)
            {
                Kanjidic2ExtensionModel? kanjidic2ExtensionModel = kanjidic2ExtensionModels
                    .Find(x => x.Literal == kanjidic2Model.Literal);

                if (kanjidic2ExtensionModel is not null)
                    _mapper.Map(kanjidic2ExtensionModel, kanjidic2Model);
            }
        }
        else if (request.FilterBy == KanjiFilterConsts.ByJLpt)
        {
            PagedResult<Kanjidic2ExtensionModel> pagedResultExtRaw = await _kanjidic2ExtensionRepository
                .GetKanjiByJlptAsync(request);

            List<string?> literals = pagedResultExtRaw.Items.Select(s => s.Literal).ToList();
            List<Kanjidic2Model> kanjidic2Models = await _kanjidic2Repository.GetItemsByLiteralsAsync(literals);

            foreach (Kanjidic2Model kanjidic2Model in kanjidic2Models)
            {
                Kanjidic2ExtensionModel? kanjidic2ExtensionModel = pagedResultExtRaw.Items
                    .Find(x => x.Literal == kanjidic2Model.Literal);

                if (kanjidic2ExtensionModel is not null)
                    _mapper.Map(kanjidic2ExtensionModel, kanjidic2Model);
            }

            pagedResultRaw = pagedResultExtRaw.CreatePagedResult(kanjidic2Models);
        }
        else
        {
            return new ExecResult<PagedResult<KanjiDetailOutput>> { Status = ExecStatus.Invalid };
        }

        PagedResult<KanjiDetailOutput>? paged = pagedResultRaw.CreatePagedResult(_mapper
            .Map<List<Kanjidic2Model>, List<KanjiDetailOutput>>(pagedResultRaw.Items));

        return new ExecResult<PagedResult<KanjiDetailOutput>>
        {
            Status = ExecStatus.Success,
            Data = paged
        };
    }
}