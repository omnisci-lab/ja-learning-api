using Japanese.Models.Common;
using khothemegiatot.NoSQL.MongoDB;
using MongoDB.Bson.Serialization.Attributes;
using Redis.OM.Modeling;

namespace Japanese.Models;

[Document(IndexName = "Sentences", StorageType = StorageType.Json)]
public class SentenceModel : MongoDBModel
{
    [BsonElement("text")]
    public string? Text { get; set; }

    [BsonElement("structure")]
    public string? Structure { get; set; }

    [BsonElement("jplt")]
    public int Jlpt { get; set; }

    [BsonElement("meanings")]
    public List<SentenceMeaning>? Meanings { get; set; }

    [BsonElement("references")]
    public string? References { get; set; }
}

public class SentenceMeaning : MeaningModel { }