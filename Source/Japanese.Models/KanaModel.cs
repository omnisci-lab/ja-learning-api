using khothemegiatot.NoSQL.MongoDB;
using MongoDB.Bson.Serialization.Attributes;
using Redis.OM.Modeling;

namespace Japanese.Models;

[Document(IndexName = "Kana", StorageType = StorageType.Json)]
public class KanaModel : MongoDBModel
{
    [BsonElement("character")]
    public string? Character { get; set; }

    [BsonElement("romanization")]
    public string? Romanization { get; set; }

    [BsonElement("kanaType")]
    public string? KanaType { get; set; }

    [BsonElement("row")]
    public string? Row { get; set; }

    [BsonElement("column")]
    public string? Column { get; set; }

    [BsonElement("isDakuten")]
    public bool IsDakuten { get; set; }

    [BsonElement("isHandakuten")]
    public bool IsHandakuten { get; set; }

    [BsonElement("unicode")]
    public string? Unicode { get; set; }

    [BsonElement("description")]
    public string? Description { get; set; }
}