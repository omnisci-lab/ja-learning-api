using Amazon.DynamoDBv2.DataModel;
using Japanese.Core.CommonModels;

namespace Japanese.Models;

[DynamoDBTable("Sentences")]
public class SentenceModel : EntityBase
{
    [DynamoDBHashKey]
    [DynamoDBProperty("sentence_id")]
    public string? SentenceId { get; set; }

    [DynamoDBProperty("text")]
    public string? Text { get; set; }

    [DynamoDBProperty("structure")]
    public string? Structure { get; set; }

    [DynamoDBProperty("jplt")]
    public int Jlpt { get; set; }

    [DynamoDBProperty("en_meanings")]
    public string? EnMeanings { get; set; }

    [DynamoDBProperty("vi_meanings")]
    public string? ViMeanings { get; set; }

    [DynamoDBProperty("references")]
    public string? References { get; set; }
}