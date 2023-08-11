using Amazon.DynamoDBv2.DataModel;

namespace Japanese.Models;

[DynamoDBTable("JlptKanji")]
public class JlptKanjiModel
{
    [DynamoDBHashKey(AttributeName = "jlpt_level")]
    public int JlptLevel { get; set; }

    [DynamoDBRangeKey(AttributeName = "kanji")]
    public string? Kanji { get; set; }
}