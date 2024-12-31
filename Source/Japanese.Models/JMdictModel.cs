using Japanese.Core.MongoDB;
using MongoDB.Bson.Serialization.Attributes;
using Redis.OM.Modeling;

namespace Japanese.Models;

[Document(IndexName = "JMdict", StorageType = StorageType.Json)]
public class JMdictModel : MongoDBModel
{
    [BsonElement("id")]
    public string? DictId { get; set; }

    [BsonElement("kana")]
    public List<KanaModel>? Kana { get; set; }

    [BsonElement("kanji")]
    public List<object>? Kanji { get; set; }

    [BsonElement("sense")]
    public List<KanaModel>? Sense { get; set; }


    public class KanaModel
    {
        [BsonElement("appliesToKanji")]
        public List<string>? AppliesToKanji { get; set; }

        [BsonElement("common")]
        public bool Common { get; set; }

        [BsonElement("tags")]
        public List<object>? Tags { get; set; }

        [BsonElement("text")]
        public string? Text { get; set; }
    }

    public class SenseModel
    {
        [BsonElement("antonym")]
        public List<object>? Antonym { get; set; }

        [BsonElement("appliesToKana")]
        public List<string>? AppliesToKana { get; set; }

        [BsonElement("appliesToKanji")]
        public List<string>? AppliesToKanji { get; set; }

        [BsonElement("dialect")]
        public List<object>? Dialect { get; set; }

        [BsonElement("field")]
        public List<object>? Field { get; set; }

        [BsonElement("gloss")]
        public List<GlossModel>? Gloss { get; set; }

        [BsonElement("info")]
        public List<object>? Info { get; set; }

        [BsonElement("languageSource")]
        public List<object>? LanguageSource { get; set; }

        [BsonElement("misc")]
        public List<object>? Misc { get; set; }

        [BsonElement("partOfSpeech")]
        public List<string>? PartOfSpeech { get; set; }

        [BsonElement("related")]
        public List<List<string>>? Related { get; set; }
    }

    public class GlossModel
    {
        [BsonElement("gender")]
        public object? Gender { get; set; }

        [BsonElement("lang")]
        public string? Lang { get; set; }

        [BsonElement("text")]
        public string? Text { get; set; }

        [BsonElement("type")]
        public object? Type { get; set; }
    }
}
