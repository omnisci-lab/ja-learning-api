using AutoMapper;
using Japanese.Repositories.Interfaces;
using khothemegiatot.WebApi.Models;
using MediatR;

namespace Japanese.Services.CommonWord.Commands.CreateAndUpdateCWord;

public class CreateAndUpdateCWordCommandHandler : IRequestHandler<CreateAndUpdateCWordCommand, ExecResult>
{
    private readonly ICommonWordRepository _commonWordRepository;
    private readonly IMapper _mapper;

    public CreateAndUpdateCWordCommandHandler(IJapaneseRepository repository, IMapper mapper)
    {
        _commonWordRepository = repository.CommonWordRepository;
        _mapper = mapper;
    }

    public async Task<ExecResult> Handle(CreateAndUpdateCWordCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}