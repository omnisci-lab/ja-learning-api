
using Amazon.DynamoDBv2.DataModel;

namespace Japanese.Models;

[DynamoDBTable("Kanken")]
public class KankenModel
{
    [DynamoDBHashKey(AttributeName = "kanken_level")]
    public string? KankenLevel { get; set; }

    [DynamoDBRangeKey(AttributeName = "kanji")]
    public string? Kanji { get; set; }
}