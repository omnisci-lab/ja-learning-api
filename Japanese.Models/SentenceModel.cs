using Amazon.DynamoDBv2.DataModel;
using Japanese.Core.MongoDB;

namespace Japanese.Models;

[DynamoDBTable("Sentences")]
public class SentenceModel : MongoDBModel
{
    [DynamoDBHashKey]
    [DynamoDBProperty("sentence_id")]
    public string? SentenceId { get; set; }

    [DynamoDBProperty("text")]
    public string? Text { get; set; }

    [DynamoDBProperty("structure")]
    public string? Structure { get; set; }

    [DynamoDBProperty("jplt")]
    public int Jlpt { get; set; }

    [DynamoDBProperty("en_meanings")]
    public string? EnMeaning { get; set; }

    [DynamoDBProperty("vi_meaning")]
    public string? ViMeaning { get; set; }

    [DynamoDBProperty("references")]
    public string? References { get; set; }

    [DynamoDBProperty("male_voice_sound")]
    public string? MaleVoiceSound { get; set; }

    [DynamoDBProperty("female_voice_sound")]
    public string? FemaleVoiceSound { get; set; }
}