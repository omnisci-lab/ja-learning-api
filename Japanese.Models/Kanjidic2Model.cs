
using Amazon.DynamoDBv2.DataModel;
using ServiceStack.DataAnnotations;

namespace Japanese.Models;

[DynamoDBTable("Kanjidic2")]
[Alias("Kanjidic2")]
public class Kanjidic2Model
{
    [DynamoDBHashKey("literal")]
    [HashKey]
    [Alias("literal")]
    public string? Literal { get; set; }

    [DynamoDBProperty("codepoints")]
    [Alias("codepoints")]
    public List<CodepointModel>? Codepoints { get; set; }

    [DynamoDBProperty("radicals")]
    [Alias("radicals")]
    public List<RadicalModel>? Radicals { get; set; }

    [DynamoDBProperty("misc")]
    [Alias("misc")]
    public MiscModel? Misc { get; set; }

    [DynamoDBProperty("dictionaryReferences")]
    [Alias("dictionaryReferences")]
    public List<DictionaryReferenceModel>? DictionaryReferences { get; set; }

    [DynamoDBProperty("queryCodes")]
    [Alias("queryCodes")]
    public List<QueryCodeModel>? QueryCodes { get; set; }

    [DynamoDBProperty("readingMeaning")]
    [Alias("readingMeaning")]
    public ReadingMeaningModel? ReadingMeaning { get; set; }

    
    public class CodepointModel
    {
        [DynamoDBProperty("type")]
        [Alias("type")]
        public string? Type { get; set; }

        [DynamoDBProperty("value")]
        [Alias("value")]
        public string? Value { get; set; }
    }

    public class RadicalModel
    {
        [DynamoDBProperty("type")]
        [Alias("type")]
        public string? Type { get; set; }

        [DynamoDBProperty("value")]
        [Alias("value")]
        public int? Value { get; set; }
    }

    public class MiscModel
    {
        [DynamoDBProperty("grade")]
        [Alias("grade")]
        public int? Grade { get; set; }

        [DynamoDBProperty("strokeCounts")]
        [Alias("strokeCounts")]
        public List<int>? StrokeCounts { get; set; }

        [DynamoDBProperty("variants")]
        [Alias("variants")]
        public List<CodepointModel>? Variants { get; set; }

        [DynamoDBProperty("frequency")]
        [Alias("frequency")]
        public int? Frequency { get; set; }

        [DynamoDBProperty("radicalNames")]
        [Alias("radicalNames")]
        public List<object>? RadicalNames { get; set; }

        [DynamoDBProperty("jlptLevel")]
        [Alias("jlptLevel")]
        public int? JlptLevel { get; set; }
    }

    public class DictionaryReferenceModel
    {
        [DynamoDBProperty("type")]
        [Alias("type")]
        public string? Type { get; set; }

        [DynamoDBProperty("morohashi")]
        [Alias("morohashi")]
        public object? Morohashi { get; set; }

        [DynamoDBProperty("value")]
        [Alias("value")]
        public string? Value { get; set; }
    }

    public class QueryCodeModel
    {
        [DynamoDBProperty("type")]
        [Alias("type")]
        public string? Type { get; set; }

        [DynamoDBProperty("skipMisclassification")]
        [Alias("skipMisclassification")]
        public object? SkipMisclassification { get; set; }

        [DynamoDBProperty("value")]
        [Alias("value")]
        public string? Value { get; set; }
    }

    public class ReadingMeaningModel
    {
        [DynamoDBProperty("groups")]
        [Alias("groups")]
        public List<GroupModel>? Groups { get; set; }

        [DynamoDBProperty("nanori")]
        [Alias("nanori")]
        public List<string>? Nanori { get; set; }
    }

    public class GroupModel
    {
        [DynamoDBProperty("readings")]
        [Alias("readings")]
        public List<ReadingModel>? Readings { get; set; }

        [DynamoDBProperty("meanings")]
        [Alias("meanings")]
        public List<MeaningModel>? Meanings { get; set; }
    }

    public class ReadingModel
    {
        [DynamoDBProperty("type")]
        [Alias("type")]
        public string? Type { get; set; }

        [DynamoDBProperty("onType")]
        [Alias("onType")]
        public object? OnType { get; set; }

        [DynamoDBProperty("status")]
        [Alias("status")]
        public object? Status { get; set; }

        [DynamoDBProperty("value")]
        [Alias("value")]
        public string? Value { get; set; }
    }

    public class MeaningModel
    {
        [DynamoDBProperty("lang")]
        [Alias("lang")]
        public string? Lang { get; set; }

        [DynamoDBProperty("value")]
        [Alias("value")]
        public string? Value { get; set; }
    }
}
