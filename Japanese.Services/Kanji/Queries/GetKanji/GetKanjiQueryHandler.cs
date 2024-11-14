using AutoMapper;
using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.Core.Queue;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using Japanese.Services.Kanji.Queue;
using MediatR;

namespace Japanese.Services.Kanji.Queries.GetKanji;

public class GetKanjiQueryHandler : IRequestHandler<GetKanjiQuery, ExecResult<KanjiDetailOutput?>>
{
    private readonly IKanjiRepository _kanjiRepository;
    private readonly IMapper _mapper;
    private readonly QueueService<KanjiQueueTask> _queueService;

    public GetKanjiQueryHandler(IJapaneseRepository repository, IMapper mapper, QueueService<KanjiQueueTask> queueService)
    {
        _kanjiRepository = repository.KanjiRepository;
        _mapper = mapper;
        _queueService = queueService;
    }

    public async Task<ExecResult<KanjiDetailOutput?>> Handle(GetKanjiQuery request, CancellationToken cancellationToken)
    {
        KanjiModel kanjiModel = await _kanjiRepository.GetByLiteralAsync(request.Kanji!);
        if (kanjiModel is null)
        {
            _queueService.EnqueueTask(new KanjiQueueTask { SyncKanjidic2ToMainDb = true });

            return new ExecResult<KanjiDetailOutput?> { Status = ExecStatus.NotFound };
        }

        return new ExecResult<KanjiDetailOutput?>
        {
            Status = ExecStatus.Success,
            Data = _mapper.Map<KanjiModel, KanjiDetailOutput>(kanjiModel!)
        };
    }
}