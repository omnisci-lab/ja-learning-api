using Japanese.Core.MongoDB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Japanese.Models;

public class Kanjidic2ExtensionModel : MongoDBModel
{
    [BsonElement("literal")]
    public string? Literal { get; set; }

    [BsonElement("jlptLevel")]
    public int? JlptLevel { get; set; }

    [BsonElement("kankenLevel")]
    public int? KankenLevel { get; set; }
}