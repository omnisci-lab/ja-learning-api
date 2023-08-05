using Amazon.DynamoDBv2.DataModel;
using Japanese.Core.CommonModels;
using ServiceStack.DataAnnotations;

namespace Japanese.Models;

[DynamoDBTable("Sentences")]
[Alias("Sentences")]
public class SentenceModel : EntityBase
{
    [DynamoDBHashKey]
    [HashKey]
    [DynamoDBProperty("sentence_id")]
    [Alias("sentence_id")]
    public string? SentenceId { get; set; }

    [DynamoDBProperty("text")]
    [Alias("sentence_id")]
    public string? Text { get; set; }

    [DynamoDBProperty("structure")]
    [Alias("sentence_id")]
    public string? Structure { get; set; }

    [DynamoDBProperty("jplt")]
    [Alias("sentence_id")]
    public int Jlpt { get; set; }

    [DynamoDBProperty("en_meanings")]
    [Alias("sentence_id")]
    public string? EnMeaning { get; set; }

    [DynamoDBProperty("vi_meaning")]
    [Alias("sentence_id")]
    public string? ViMeaning { get; set; }

    [DynamoDBProperty("references")]
    [Alias("sentence_id")]
    public string? References { get; set; }

    [DynamoDBProperty("male_voice_sound")]
    [Alias("sentence_id")]
    public string? MaleVoiceSound { get; set; }

    [DynamoDBProperty("female_voice_sound")]
    [Alias("sentence_id")]
    public string? FemaleVoiceSound { get; set; }
}