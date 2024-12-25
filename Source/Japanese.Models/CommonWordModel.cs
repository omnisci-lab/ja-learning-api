using Japanese.Core.MongoDB;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Japanese.Models.Common;
using Redis.OM.Modeling;

namespace Japanese.Models;

[Document(IndexName = "CommonWords", StorageType = StorageType.Json)]
public class CommonWordModel : MongoDBModel
{
    [BsonElement("word")]
    public string? Word { get; set; }

    [BsonElement("meaning")]
    public List<CommonWordMeaning>? Meanings { get; set; }

    [BsonElement("reading")]
    public List<CommonWordReading>? Readings { get; set; }

    [BsonElement("notes")]
    public List<CommonWordNote>? Notes { get; set; }
}

public class CommonWordMeaning : ReadingModel { }

public class CommonWordReading : ReadingModel { }

public class CommonWordNote : NoteModel { }