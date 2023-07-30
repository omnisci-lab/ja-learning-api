using Japanese.Core.CommonModels;
using MediatR;

namespace Japanese.Services.Common.Queries.ConvertToRomaji;

public class ConvertToRomajiQuery : IRequest<ExecResult<string>>
{
    public string? Text { get; set; }
}