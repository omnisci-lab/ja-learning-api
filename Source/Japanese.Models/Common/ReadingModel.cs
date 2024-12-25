

using MongoDB.Bson.Serialization.Attributes;

namespace Japanese.Models.Common;

public class ReadingModel
{
    [BsonElement("type")]
    public string? Type { get; set; }

    [BsonElement("value")]
    public string? Value { get; set; }
}
