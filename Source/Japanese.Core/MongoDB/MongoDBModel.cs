using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Japanese.Core.MongoDB;

public class MongoDBModel
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonIgnoreIfNull]
    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; }

    [BsonIgnoreIfNull]
    [BsonElement("updatedAt")]
    public DateTime UpdatedAt { get; set; }

    [BsonIgnoreIfNull]
    [BsonElement("deletedAt")]
    public DateTime DeletedAt { get; set; }
}