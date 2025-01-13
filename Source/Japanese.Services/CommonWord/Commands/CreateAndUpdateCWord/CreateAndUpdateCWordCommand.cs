using khothemegiatot.WebApi.Models;
using MediatR;

namespace Japanese.Services.CommonWord.Commands.CreateAndUpdateCWord;

public class CreateAndUpdateCWordCommand : IRequest<ExecResult>
{
    public bool IsUpdate { get; set; }

    public string? WordId { get; set; }
    public string? Word { get; set; }
}