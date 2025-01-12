using khothemegiatot.WebApi.CQRS.Commands;
using khothemegiatot.WebApi.Models;
using MediatR;

namespace Japanese.Services.Kanji.Commands.DeleteKanji;

public class DeleteKanjiCommand : IRequest<ExecResult>, IDeleteCommand
{
    public string? Character { get; set; }
    public bool ForceDelete { get; set; }
}