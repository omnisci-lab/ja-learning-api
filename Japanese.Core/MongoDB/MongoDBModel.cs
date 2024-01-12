using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Japanese.Core.MongoDB;

public class MongoDBModel
{
    [BsonId]
    public ObjectId Id { get; set; }
}