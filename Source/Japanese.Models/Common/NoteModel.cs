
using MongoDB.Bson.Serialization.Attributes;

namespace Japanese.Models.Common;

public class NoteModel
{
    [BsonElement("lang")]
    public string? Lang { get; set; }

    [BsonElement("title")]
    public string? Title { get; set; }

    [BsonElement("content")]
    public string? Content { get; set; }
}
