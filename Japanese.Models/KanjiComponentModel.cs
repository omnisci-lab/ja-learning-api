using Amazon.DynamoDBv2.DataModel;

namespace Japanese.Models;

[DynamoDBTable("KanjiComponents")]
public class KanjiComponentModel
{
    [DynamoDBHashKey(AttributeName = "kanji")]
    public string? Kanji { get; set; }

    [DynamoDBProperty("components")]
    public List<string>? Components { get; set; }
}