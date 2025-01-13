using khothemegiatot.NoSQL.MongoDB;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Redis.OM.Modeling;

namespace Japanese.Models;

[Document(IndexName = "Dictionary", StorageType = StorageType.Json)]

public class DictionaryModel : MongoDBModel
{
    //Trong tiếng Nhật, 1 từ có thể viết nhiều kiểu dựa trên tổ hợp cách sử dụng 3 loại chữ
    [BsonElement("words")]
    public List<JapanseWord>? Words { get; set; }

    [BsonElement("romaji")]
    public string? Romaji { get; set; }

    [BsonElement("partOfSpeech")]
    public string? PartOfSpeech { get; set; } // Loại từ

    [BsonElement("translations")]
    public List<Translation>? Translations { get; set; }
}

public class JapanseWord
{
    [BsonElement("word")]
    public string? Word { get; set; }
}

public class Translation
{
    [BsonElement("language")]
    public string? Language { get; set; }

    [BsonElement("translatedWord")]
    public string? TranslatedWord { get; set; }
}
