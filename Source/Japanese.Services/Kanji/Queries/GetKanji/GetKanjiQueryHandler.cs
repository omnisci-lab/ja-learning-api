using AutoMapper;
using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.Core.Queue;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using Japanese.Services.Kanji.Queues;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Japanese.Services.Kanji.Queries.GetKanji;

public class GetKanjiQueryHandler : IRequestHandler<GetKanjiQuery, ExecResult<KanjiDetailOutput?>>
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly IKanjiRepository _kanjiRepository;
    private readonly IKanjidic2Repository _kanjidic2Repository;
    private readonly IMapper _mapper;
    private readonly QueueService<KanjiQueueTask> _queueService;

    public GetKanjiQueryHandler(IServiceScopeFactory serviceScopeFactory, IJapaneseRepository repository, IMapper mapper, QueueService<KanjiQueueTask> queueService)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _kanjiRepository = repository.KanjiRepository;
        _kanjidic2Repository = repository.Kanjidic2Repository;
        _mapper = mapper;
        _queueService = queueService;
    }

    public async Task<ExecResult<KanjiDetailOutput?>> Handle(GetKanjiQuery request, CancellationToken cancellationToken)
    {
        KanjiModel kanjiModel = await _kanjiRepository.GetByLiteralAsync(request.Kanji!);
        if (kanjiModel is not null)
            return new ExecResult<KanjiDetailOutput?>
            {
                Status = ExecStatus.Success,
                Data = _mapper.Map<KanjiModel, KanjiDetailOutput>(kanjiModel!)
            };

        Kanjidic2Model kanjidic2Model = await _kanjidic2Repository.GetByLiteralAsync(request.Kanji!);
        if (kanjidic2Model is null)
            return new ExecResult<KanjiDetailOutput?> { Status = ExecStatus.NotFound };

        _queueService.EnqueueTask(new KanjiQueueTask(_serviceScopeFactory)
        {
            SyncKanjidic2ToMainTable = true,
            KanjiModel = _mapper.Map<Kanjidic2Model, KanjiModel>(kanjidic2Model)
        });

        return new ExecResult<KanjiDetailOutput?>
        {
            Status = ExecStatus.Success,
            Data = _mapper.Map<Kanjidic2Model, KanjiDetailOutput>(kanjidic2Model!)
        };
    }
}