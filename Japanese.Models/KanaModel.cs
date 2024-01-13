using Japanese.Core.MongoDB;
using MongoDB.Bson.Serialization.Attributes;

namespace Japanese.Models;

public class KanaModel : MongoDBModel
{
    [BsonElement("character")]
    public string? Character { get; set; }

    [BsonElement("romanization")]
    public string? Romanization { get; set; }

    [BsonElement("kanaType")]
    public string? KanaType { get; set; }
}