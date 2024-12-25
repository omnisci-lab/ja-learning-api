using MongoDB.Bson.Serialization.Attributes;

namespace Japanese.Models.Common;

public class MeaningModel
{
    [BsonElement("lang")]
    public string? LangCode { get; set; }

    [BsonElement("value")]
    public string? Value { get; set; }
}
