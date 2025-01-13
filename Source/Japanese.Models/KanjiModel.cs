using Japanese.Models.Common;
using khothemegiatot.NoSQL.MongoDB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Redis.OM.Modeling;

namespace Japanese.Models;

[Document(IndexName = "Kanji", StorageType = StorageType.Json)]
public class KanjiModel : MongoDBModel
{
    [BsonElement("character")]
    [Indexed]
    public string Character { get; set; } = default!;

    [BsonElement("strokeCount")]
    public int StrokeCount { get; set; }

    [BsonElement("level")]
    public KanjiLevel? Level { get; set; }

    [BsonElement("radicals")]
    public List<string>? Radicals { get; set; }

    [BsonElement("meanings")]
    public List<KanjiMeaning>? Meanings { get; set; }

    [BsonElement("pronunciations")]
    public List<KanjiReading>? Readings { get; set; }

    [BsonElement("examples")]
    public List<KanjiExample>? Examples { get; set; }

    [BsonElement("notes")]
    public List<KanjiNote>? Notes { get; set; }
}

public class KanjiLevel
{
    [BsonElement("jlpt")]
    public int? Jlpt { get; set; }

    [BsonElement("grade")]
    public int? Grade { get; set; }

    [BsonElement("kanken")]
    public int? Kanken { get; set; }
}

public class KanjiMeaning : MeaningModel { }


public class KanjiReading : ReadingModel { }

public class KanjiExample
{
    [BsonElement("World")]
    public string? Word { get; set; }

    [BsonElement("kana")]
    public string? Kana { get; set; }

    [BsonElement("meaning")]
    public string? Meaning { get; set; }
}

public class KanjiNote : NoteModel { }