using Amazon.DynamoDBv2.DataModel;
using Japanese.Core.CommonModels;

namespace Japanese.Models;

[DynamoDBTable("KanjiRadicals")]
public class KanjiRadicalModel : EntityBase
{
    [DynamoDBProperty("kanji_radical")]
    public string? KanjiRadical { get; set; }
}
