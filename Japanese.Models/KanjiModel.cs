using Japanese.Core.MongoDB;
using MongoDB.Bson.Serialization.Attributes;
using Redis.OM.Modeling;

namespace Japanese.Models;

public class KanjiModel : MongoDBModel
{
    [BsonElement("literal")]
    [Indexed]
    public string? Literal { get; set; }
}
