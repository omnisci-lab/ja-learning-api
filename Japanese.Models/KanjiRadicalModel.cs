using Amazon.DynamoDBv2.DataModel;

namespace Japanese.Models;

[DynamoDBTable("KanjiRadicals")]
public class KanjiRadicalModel
{
    [DynamoDBProperty("kanji_radical")]
    public string? KanjiRadical { get; set; }
}
