using Amazon.DynamoDBv2.DataModel;
using Japanese.Core.CommonModels;

namespace Japanese.Models;

[DynamoDBTable("JlptKanji")]
public class JlptKanjiModel : EntityBase
{
    [DynamoDBHashKey(AttributeName = "jlpt_level")]
    public int JlptLevel { get; set; }

    [DynamoDBRangeKey(AttributeName = "kanji")]
    public string? Kanji { get; set; }
}