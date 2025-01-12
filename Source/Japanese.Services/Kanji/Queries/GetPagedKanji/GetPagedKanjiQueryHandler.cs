using AutoMapper;
using Japanese.CachedRepository.Interfaces;
using Japanese.Core.CommonModels;
using Japanese.Core.Encoding;
using Japanese.Core.Enum;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using Japanese.Services.Kanji.Consts;
using khothemegiatot.WebApi.Enums;
using khothemegiatot.WebApi.Models;
using MediatR;

namespace Japanese.Services.Kanji.Queries.GetPagedKanji;

public class GetPagedKanjiQueryHandler : IRequestHandler<GetPagedKanjiQuery, ExecResult<PagedResult<KanjiDetailOutput>>>
{
    private readonly IKanjiRepository _kanjiRepository;
    private readonly IKanjidic2Repository _kanjidic2Repository;
    private readonly IMapper _mapper;
    private Base64 _base64;

    public GetPagedKanjiQueryHandler(IJapaneseRepository repository, IJapaneseCachedRepository cachedRepository, IMapper mapper)
    {
        _kanjiRepository = repository.KanjiRepository;
        _kanjidic2Repository = repository.Kanjidic2Repository;
        _mapper = mapper;
        _base64 = new Base64();
    }

    public async Task<ExecResult<PagedResult<KanjiDetailOutput>>> Handle(GetPagedKanjiQuery request, CancellationToken cancellationToken)
    {
        PagedResult<KanjiDetailOutput>? paged = null;
        if (request.FromKanjidic2)
        {
            PagedResult<Kanjidic2Model> pagedResultRaw1 = null!;
            if (request.FilterBy == KanjiFilterConsts.All)
            {
                pagedResultRaw1 = await _kanjidic2Repository.GetPaginatedAsync(request);
            }
            else if (request.FilterBy == KanjiFilterConsts.ByKanken)
            {
                pagedResultRaw1 = await _kanjidic2Repository.GetKanjiByKankenAsync(request);
            }
            else if (request.FilterBy == KanjiFilterConsts.ByJLpt)
            {
                pagedResultRaw1 = await _kanjidic2Repository.GetKanjiByJlptAsync(request);
            }
            else
            {
                return new ExecResult<PagedResult<KanjiDetailOutput>> { Status = ExecStatus.Invalid };
            }

            paged = pagedResultRaw1.CreatePagedResult(_mapper
            .Map<List<Kanjidic2Model>, List<KanjiDetailOutput>>(pagedResultRaw1.Items));
            
        }
        else
        {
            PagedResult<KanjiModel> pagedResultRaw2 = null!;
            if (request.FilterBy == KanjiFilterConsts.All)
            {
                pagedResultRaw2 = await _kanjiRepository.GetPaginatedAsync(request);
            }
            else if (request.FilterBy == KanjiFilterConsts.ByKanken)
            {
                pagedResultRaw2 = await _kanjiRepository.GetKanjiByKankenAsync(request);
            }
            else if (request.FilterBy == KanjiFilterConsts.ByJLpt)
            {
                pagedResultRaw2 = await _kanjiRepository.GetKanjiByJlptAsync(request);
            }
            else
            {
                return new ExecResult<PagedResult<KanjiDetailOutput>> { Status = ExecStatus.Invalid };
            }

            paged = pagedResultRaw2.CreatePagedResult(_mapper
            .Map<List<KanjiModel>, List<KanjiDetailOutput>>(pagedResultRaw2.Items));
        }

        return new ExecResult<PagedResult<KanjiDetailOutput>>
        {
            Status = ExecStatus.Success,
            Data = paged
        };
    }
}