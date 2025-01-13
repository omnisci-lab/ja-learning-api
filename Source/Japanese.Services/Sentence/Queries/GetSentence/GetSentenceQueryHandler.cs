using AutoMapper;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using khothemegiatot.WebApi.Enums;
using khothemegiatot.WebApi.Models;
using MediatR;
using MongoDB.Bson;

namespace Japanese.Services.Sentence.Queries.GetSentence;

public class GetSentenceQueryHandler : IRequestHandler<GetSentenceQuery, ExecResult<SentenceOutput?>>
{
    private readonly ISentenceRepository _sentenceRepository;
    private readonly IMapper _mapper;

    public GetSentenceQueryHandler(IJapaneseRepository repository, IMapper mapper)
    {
        _sentenceRepository = repository.SentenceRepository;
        _mapper = mapper;
    }

    public async Task<ExecResult<SentenceOutput?>> Handle(GetSentenceQuery request, CancellationToken cancellationToken)
    {
        SentenceModel? sentenceModel = await _sentenceRepository.GetAsync(ObjectId.Parse(request.SentenceId));
        if (sentenceModel is null)
            return new ExecResult<SentenceOutput?> { Status = ExecStatus.NotFound };

        return new ExecResult<SentenceOutput?>
        {
            Status = ExecStatus.Success,
            Data = _mapper.Map<SentenceModel, SentenceOutput>(sentenceModel)
        };
    }
}