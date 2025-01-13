using AutoMapper;
using Japanese.Repositories.Interfaces;
using khothemegiatot.WebApi.Models;
using MediatR;

namespace Japanese.Services.CommonWord.Queries.GetPagedCommonWords;

public class GetPagedCommonWordsQueryHandler : IRequestHandler<GetPagedCommonWordsQuery, ExecResult<PagedResult<CommonWordOutput>>>
{
    private readonly ICommonWordRepository _commonWordRepository;
    private readonly IMapper _mapper;

    public GetPagedCommonWordsQueryHandler(IJapaneseRepository repository, IMapper mapper) {
        _commonWordRepository = repository.CommonWordRepository;
        _mapper = mapper;
    }

    public Task<ExecResult<PagedResult<CommonWordOutput>>> Handle(GetPagedCommonWordsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
