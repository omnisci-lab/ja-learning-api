using Japanese.Core.MongoDB;
using MongoDB.Bson.Serialization.Attributes;

namespace Japanese.Models;

public class KanjiRadicalModel : MongoDBModel
{
    [BsonElement("kanji_radical")]
    public string? KanjiRadical { get; set; }
}