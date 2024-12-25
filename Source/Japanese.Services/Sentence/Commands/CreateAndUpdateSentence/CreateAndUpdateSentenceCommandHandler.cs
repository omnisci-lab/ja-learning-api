using AutoMapper;
using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MediatR;

namespace Japanese.Services.Sentence.Commands.CreateAndUpdateSentence;

public class CreateAndUpdateSentenceCommandHandler : IRequestHandler<CreateAndUpdateSentenceCommand, ExecResult>
{
    private readonly ISentenceRepository _sentenceRepository;
    private readonly IMapper _mapper;

    public CreateAndUpdateSentenceCommandHandler(IJapaneseRepository repository, IMapper mapper)
    {
        _sentenceRepository = repository.SentenceRepository;
        _mapper = mapper;
    }

    public async Task<ExecResult> Handle(CreateAndUpdateSentenceCommand request, CancellationToken cancellationToken)
    {
        if (request.IsUpdate)
        {
            SentenceModel sentenceModel = await _sentenceRepository.GetAsync(new MongoDB.Bson.ObjectId());
            if (sentenceModel is null)
                return new ExecResult { Status = ExecStatus.NotFound };

            _ = _mapper.Map(request, sentenceModel);
            await _sentenceRepository.UpdateAsync(null, null, null);

            return new ExecResult { Status = ExecStatus.Success };
        }

        //bool exists = await _sentenceRepository.Exists(x => x.SentenceId == request.SentenceId);
        //if (!exists)
        //    return new ExecResult { Status = ExecStatus.AlreadyExists };

        SentenceModel newSentenceModel = _mapper.Map<CreateAndUpdateSentenceCommand, SentenceModel>(request);

        return new ExecResult { Status = ExecStatus.Success };
    }
}
