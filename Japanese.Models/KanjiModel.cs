using Amazon.DynamoDBv2.DataModel;
using Japanese.Core.CommonModels;

namespace Japanese.Models;

[DynamoDBTable("Kanji")]
public class KanjiModel : EntityBase
{
    [DynamoDBHashKey]
    [DynamoDBProperty("kanji")]
    public string? Kanji { get; set; }

    [DynamoDBProperty("stroke_count")]
    public int StrokeCount { get; set; }

    [DynamoDBProperty("grade")]
    public int? Grade { get; set; }

    [DynamoDBProperty("on_readings")]
    public List<string>? OnReadings { get; set; }

    [DynamoDBProperty("kun_readings")]
    public List<string>? KunReadings { get; set; }

    [DynamoDBProperty("name_readings")]
    public List<string>? NameReadings { get; set; }

    [DynamoDBProperty("meanings")]
    public List<string>? EnMeanings { get; set; }

    [DynamoDBProperty("sino_vietnames")]
    public List<string>? SinoVietnamese { get; set; }

    [DynamoDBProperty("vi_meanings")]
    public List<string>? ViMeanings { get; set; }

    [DynamoDBProperty("jlpt")]
    public int? Jlpt { get; set; }

    [DynamoDBProperty("unicode")]
    public string? Unicode { get; set; }
}