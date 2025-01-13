using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using khothemegiatot.NoSQL.MongoDB;

namespace Japanese.Models;

public class KanjiComponentModel : MongoDBModel
{
    [BsonElement("literal")]
    public string? Literal { get; set; }

    [BsonElement("components")]
    public List<string>? Components { get; set; }
}