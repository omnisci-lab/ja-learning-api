using Japanese.Core.MongoDB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Redis.OM.Modeling;

namespace Japanese.Models;

[Document(IndexName = "kanji2dic", StorageType = StorageType.Json)]
public class Kanjidic2Model : MongoDBModel
{
    [BsonElement("literal")]
    [Indexed]
    public string? Literal { get; set; }

    [BsonElement("codepoints")]
    public List<CodepointModel>? Codepoints { get; set; }

    [BsonElement("radicals")]
    public List<RadicalModel>? Radicals { get; set; }

    [BsonElement("misc")]
    public MiscModel? Misc { get; set; }

    [BsonElement("dictionaryReferences")]
    public List<DictionaryReferenceModel>? DictionaryReferences { get; set; }

    [BsonElement("queryCodes")]
    public List<QueryCodeModel>? QueryCodes { get; set; }

    [BsonElement("readingMeaning")]
    public ReadingMeaningModel? ReadingMeaning { get; set; }

    
    public class CodepointModel
    {
        [BsonElement("type")]
        public string? Type { get; set; }

        [BsonElement("value")]
        public string? Value { get; set; }
    }

    public class RadicalModel
    {
        [BsonElement("type")]
        public string? Type { get; set; }

        [BsonElement("value")]
        public int? Value { get; set; }
    }

    public class MiscModel
    {
        [BsonElement("grade")]
        public int? Grade { get; set; }

        [BsonElement("strokeCounts")]
        public List<int>? StrokeCounts { get; set; }

        [BsonElement("variants")]
        public List<CodepointModel>? Variants { get; set; }

        [BsonElement("frequency")]
        public int? Frequency { get; set; }

        [BsonElement("radicalNames")]
        public List<object>? RadicalNames { get; set; }

        [BsonElement("jlptLevel")]
        public int? JlptLevel { get; set; }

        [BsonIgnore]
        public int? KankenLevel { get; set; }
    }

    public class DictionaryReferenceModel
    {
        [BsonElement("type")]
        public string? Type { get; set; }

        [BsonElement("morohashi")]
        public object? Morohashi { get; set; }

        [BsonElement("value")]
        public string? Value { get; set; }
    }

    public class QueryCodeModel
    {
        [BsonElement("type")]
        public string? Type { get; set; }

        [BsonElement("skipMisclassification")]
        public object? SkipMisclassification { get; set; }

        [BsonElement("value")]
        public string? Value { get; set; }
    }

    public class ReadingMeaningModel
    {
        [BsonElement("groups")]
        public List<GroupModel>? Groups { get; set; }

        [BsonElement("nanori")]
        public List<string>? Nanori { get; set; }
    }

    public class GroupModel
    {
        [BsonElement("readings")]
        public List<ReadingModel>? Readings { get; set; }

        [BsonElement("meanings")]
        public List<MeaningModel>? Meanings { get; set; }
    }

    public class ReadingModel
    {
        [BsonElement("type")]
        public string? Type { get; set; }

        [BsonElement("onType")]
        public object? OnType { get; set; }

        [BsonElement("status")]
        public object? Status { get; set; }

        [BsonElement("value")]
        public string? Value { get; set; }
    }

    public class MeaningModel
    {
        [BsonElement("lang")]
        public string? Lang { get; set; }

        [BsonElement("value")]
        public string? Value { get; set; }
    }
}
