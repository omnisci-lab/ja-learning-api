using Japanese.Core.MongoDB;
using MongoDB.Bson.Serialization.Attributes;

namespace Japanese.Models;

public class SentenceModel : MongoDBModel
{
    [BsonElement("sentenceId")]
    public string? SentenceId { get; set; }

    [BsonElement("text")]
    public string? Text { get; set; }

    [BsonElement("structure")]
    public string? Structure { get; set; }

    [BsonElement("jplt")]
    public int Jlpt { get; set; }

    [BsonElement("en_meanings")]
    public string? EnMeaning { get; set; }

    [BsonElement("vi_meaning")]
    public string? ViMeaning { get; set; }

    [BsonElement("references")]
    public string? References { get; set; }

    [BsonElement("male_voice_sound")]
    public string? MaleVoiceSound { get; set; }

    [BsonElement("female_voice_sound")]
    public string? FemaleVoiceSound { get; set; }
}