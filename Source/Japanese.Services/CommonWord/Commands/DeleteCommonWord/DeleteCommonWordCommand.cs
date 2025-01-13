using khothemegiatot.WebApi.CQRS.Commands;
using khothemegiatot.WebApi.Models;
using MediatR;

namespace Japanese.Services.CommonWord.Commands.DeleteCommonWord;

public class DeleteCommonWordCommand : IRequest<ExecResult>, IDeleteCommand
{
    public bool ForceDelete { get; set; }

    public string? WordId { get; set; }
}
