using Amazon.DynamoDBv2.DataModel;

namespace Japanese.Models;

[DynamoDBTable("Kana")]
public class KanaModel
{
    [DynamoDBHashKey(AttributeName = "kana_type")]
    public string? KanaType { get; set; }

    [DynamoDBRangeKey(AttributeName = "character")]
    public string? Character { get; set; }
}