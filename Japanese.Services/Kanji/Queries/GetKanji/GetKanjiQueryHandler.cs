using AutoMapper;
using Grpc.Net.Client;
using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using Japanese.Services.Protos;
using MediatR;

namespace Japanese.Services.Kanji.Queries.GetKanji;

public class GetKanjiQueryHandler : IRequestHandler<GetKanjiQuery, ExecResult<KanjiDetailOutput?>>
{
    private readonly IKanjiRepository _kanjiRepository;
    private readonly IMapper _mapper;
    private readonly GrpcChannel _grpcChannel;
    private readonly Kanjidic2.Kanjidic2Client _kanjidic2Client;

    public GetKanjiQueryHandler(IJapaneseRepository repository, IMapper mapper, GrpcChannel grpcChannel)
    {
        _kanjiRepository = repository.KanjiRepository;
        _mapper = mapper;
        _grpcChannel = grpcChannel;
        _kanjidic2Client = new Kanjidic2.Kanjidic2Client(_grpcChannel);
    }

    public async Task<ExecResult<KanjiDetailOutput?>> Handle(GetKanjiQuery request, CancellationToken cancellationToken)
    {
        KanjiModel kanjiModel = await _kanjiRepository.GetByLiteralAsync(request.Kanji!);
        if (kanjiModel is null)
        {
            Kanjidic2Output kanjidic2 = await _kanjidic2Client.GetKanjiAsync(new GetKanjiRequest { Literal = request.Kanji });
            if(kanjidic2 is null)
                return new ExecResult<KanjiDetailOutput?> { Status = ExecStatus.NotFound };

             _mapper.Map(kanjidic2, kanjiModel);
        }

        return new ExecResult<KanjiDetailOutput?>
        {
            Status = ExecStatus.Success,
            Data = _mapper.Map<KanjiModel, KanjiDetailOutput>(kanjiModel!)
        };
    }
}