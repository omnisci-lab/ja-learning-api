using Japanese.Core.MongoDB;
using Japanese.Models.Common;
using MongoDB.Bson.Serialization.Attributes;
using Redis.OM.Modeling;

namespace Japanese.Models;

[Document(IndexName = "KanjiRadicals", StorageType = StorageType.Json)]
public class KanjiRadicalModel : MongoDBModel
{
    [BsonElement("character")]
    public string? Character { get; set; }

    [BsonElement("strokes")]
    public int Strokes { get; set; }

    [BsonElement("unicode")]
    public string? Unicode { get; set; }

    [BsonElement("meaning")]
    public List<KradMeaning>? Meanings { get; set; }

    [BsonElement("readings")]
    public List<KradReading>? Readings { get; set; }

    [BsonElement("notes")]
    public List<KradNote>? NoteModels { get; set; }
}

public class KradMeaning : MeaningModel { }

public class KradReading : ReadingModel { }

public class KradNote : NoteModel { }