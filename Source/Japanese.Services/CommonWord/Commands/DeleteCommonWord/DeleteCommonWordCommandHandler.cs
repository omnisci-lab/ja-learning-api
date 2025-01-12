using Japanese.Core.CommonModels;
using khothemegiatot.WebApi.Models;
using MediatR;

namespace Japanese.Services.CommonWord.Commands.DeleteCommonWord;

public class DeleteCommonWordCommandHandler : IRequestHandler<DeleteCommonWordCommand, ExecResult>
{
    public Task<ExecResult> Handle(DeleteCommonWordCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
