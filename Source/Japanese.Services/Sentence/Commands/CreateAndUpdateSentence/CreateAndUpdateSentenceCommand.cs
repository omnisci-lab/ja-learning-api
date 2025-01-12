using Japanese.Core.CommonModels;
using khothemegiatot.WebApi.Models;
using MediatR;

namespace Japanese.Services.Sentence.Commands.CreateAndUpdateSentence;

public class CreateAndUpdateSentenceCommand : IRequest<ExecResult>
{
    public bool IsUpdate { get; set; }

    public string? SentenceId { get; set; }
    public string? Text { get; set; }
    public string? Structure { get; set; }
    public int Jlpt { get; set; }
    public string? EnMeaning { get; set; }
    public string? ViMeaning { get; set; }
    public string? References { get; set; }
}