using Japanese.Core.CommonModels;
using MediatR;

namespace Japanese.Services.Kana.Commands.CreateAndUpdateKana;

public class CreateAndUpdateKanaCommand : IRequest<ExecResult>
{
    public bool IsUpdate { get; set; }

    public string? Character { get; set; }
    public string? Romanization { get; set; }
    public string? KanaType { get; set; }
}