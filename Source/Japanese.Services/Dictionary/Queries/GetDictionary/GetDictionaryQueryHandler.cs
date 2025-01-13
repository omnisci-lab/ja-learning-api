using AutoMapper;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using khothemegiatot.WebApi.Enums;
using khothemegiatot.WebApi.Models;
using MediatR;
using MongoDB.Bson;

namespace Japanese.Services.Dictionary.Queries.GetDictionary;

public class GetDictionaryQueryHandler : IRequestHandler<GetDictionaryQuery, ExecResult<DictionaryOutput>>
{
    private readonly IDictionaryRepository _dictionaryRepository;
    private readonly IMapper _mapper;

    public GetDictionaryQueryHandler(IJapaneseRepository repository, IMapper mapper)
    {
        _dictionaryRepository = repository.DictionaryRepository;
        _mapper = mapper;
    }

    public async Task<ExecResult<DictionaryOutput>> Handle(GetDictionaryQuery request, CancellationToken cancellationToken)
    {
        DictionaryModel dictionaryModel = await _dictionaryRepository.GetAsync(ObjectId.Parse(""));
        if (dictionaryModel == null)
            return new ExecResult<DictionaryOutput> { Status = ExecStatus.Success };

        DictionaryOutput dictionaryOutput = _mapper.Map<DictionaryModel, DictionaryOutput>(dictionaryModel);

        return new ExecResult<DictionaryOutput> { Status = ExecStatus.Success, Data = dictionaryOutput };
    }
}
