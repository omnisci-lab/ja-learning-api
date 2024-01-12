using Amazon.DynamoDBv2.DataModel;
using Japanese.Core.MongoDB;

namespace Japanese.Models;

[DynamoDBTable("Kana")]
public class KanaModel : MongoDBModel
{
    [DynamoDBHashKey(AttributeName = "kana_type")]
    public string? KanaType { get; set; }

    [DynamoDBRangeKey(AttributeName = "character")]
    public string? Character { get; set; }
}