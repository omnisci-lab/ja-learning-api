
namespace Japanese.Services.Sentence.Queries;

public class SentenceOutput
{
    public string? SentenceId { get; set; }
    public string? Text { get; set; }
    public string? Structure { get; set; }
    public int Jlpt { get; set; }
    public string? EnMeaning { get; set; }
    public string? ViMeaning { get; set; }
    public string? References { get; set; }
}
