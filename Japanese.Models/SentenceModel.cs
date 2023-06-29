using Amazon.DynamoDBv2.DataModel;
using Japanese.Core.CommonModels;

namespace Japanese.Models;

[DynamoDBTable("Sentences")]
public class SentenceModel : EntityBase
{
    [DynamoDBProperty("sentence_id")]
    public string? SentenceId { get; set; }
}