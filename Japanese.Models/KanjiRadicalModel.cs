using Amazon.DynamoDBv2.DataModel;
using Japanese.Core.MongoDB;

namespace Japanese.Models;

[DynamoDBTable("KanjiRadicals")]
public class KanjiRadicalModel : MongoDBModel
{
    [DynamoDBProperty("kanji_radical")]
    public string? KanjiRadical { get; set; }
}
