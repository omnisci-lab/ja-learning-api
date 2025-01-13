using AutoMapper;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using khothemegiatot.WebApi.Enums;
using khothemegiatot.WebApi.Models;
using MediatR;
using MongoDB.Bson;

namespace Japanese.Services.CommonWord.Queries.GetCommonWord;

public class GetCommonWordQueryHandler : IRequestHandler<GetCommonWordQuery, ExecResult<CommonWordOutput>>
{
    private readonly ICommonWordRepository _commonWordRepository;
    private readonly IMapper _mapper;

    public GetCommonWordQueryHandler(IJapaneseRepository repository, IMapper mapper)
    {
        _commonWordRepository = repository.CommonWordRepository;
        _mapper = mapper;
    }

    public async Task<ExecResult<CommonWordOutput>> Handle(GetCommonWordQuery request, CancellationToken cancellationToken)
    {
        CommonWordModel wordModel = await _commonWordRepository.GetAsync(ObjectId.Parse(request.WordId));
        if(wordModel is null)
            return new ExecResult<CommonWordOutput> { Status = ExecStatus.NotFound };

        CommonWordOutput wordOutput =  _mapper.Map<CommonWordModel, CommonWordOutput>(wordModel);

        return new ExecResult<CommonWordOutput> { Status = ExecStatus.Success, Data = wordOutput };
    }
}
