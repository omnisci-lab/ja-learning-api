using AutoMapper;
using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MediatR;

namespace Japanese.Services.Kanji.Queries.GetKanji;

public class GetKanjiQueryHandler : IRequestHandler<GetKanjiQuery, ExecResult<KanjiDetailOutput?>>
{
    private readonly IKanjiRepository _kanjiRepository;
    private readonly IKanjidic2Repository _kanjidic2Repository;
    private readonly IMapper _mapper;

    public GetKanjiQueryHandler(IJapaneseRepository repository, IMapper mapper)
    {
        _kanjiRepository = repository.KanjiRepository;
        _kanjidic2Repository = repository.Kanjidic2Repository;
        _mapper = mapper;
    }

    public async Task<ExecResult<KanjiDetailOutput?>> Handle(GetKanjiQuery request, CancellationToken cancellationToken)
    {
        KanjiModel? kanjiModel = await _kanjiRepository.GetAsync(request.Kanji);
        if (kanjiModel is null)
            return new ExecResult<KanjiDetailOutput?> { Status = ExecStatus.NotFound };

        Kanjidic2Model? kanjidic2Model = await _kanjidic2Repository.GetAsync(request.Kanji);

        List<Kanjidic2Model.GroupModel> groupModels = kanjidic2Model!.ReadingMeaning!.Groups!;

        List<string> sinoVietnamese = new List<string>();
        foreach(Kanjidic2Model.GroupModel groupModel in groupModels)
        {
            foreach(Kanjidic2Model.ReadingModel readingModel in groupModel.Readings!.Where(r => r.Type == "vietnam"))
            {
                sinoVietnamese.Add(readingModel.Value);
            }
        }

        kanjiModel.SinoVietnamese = sinoVietnamese;

        return new ExecResult<KanjiDetailOutput?>
        {
            Status = ExecStatus.Success,
            Data = _mapper.Map<KanjiModel, KanjiDetailOutput>(kanjiModel)
        };
    }
}
