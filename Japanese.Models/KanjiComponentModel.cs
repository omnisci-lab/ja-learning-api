using Amazon.DynamoDBv2.DataModel;
using Japanese.Core.CommonModels;
using ServiceStack.DataAnnotations;

namespace Japanese.Models;

[DynamoDBTable("KanjiComponents")]
[Alias("KanjiComponents")]
public class KanjiComponentModel : EntityBase
{
    [DynamoDBHashKey(AttributeName = "kanji")]
    [Alias("kanji")]
    public string? Kanji { get; set; }

    [DynamoDBProperty("components")]
    [Alias("components")]
    public List<string>? Components { get; set; }
}