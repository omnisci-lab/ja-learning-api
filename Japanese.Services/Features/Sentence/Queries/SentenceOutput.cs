using Amazon.DynamoDBv2.DataModel;

namespace Japanese.Services.Features.Sentence.Queries;

public class SentenceOutput
{
    public string? SentenceId { get; set; }

    public string? Text { get; set; }

    public string? EnMeanings { get; set; }

    public string? ViMeanings { get; set; }
}
