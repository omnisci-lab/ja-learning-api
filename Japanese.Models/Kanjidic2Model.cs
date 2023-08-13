
using Amazon.DynamoDBv2.DataModel;

namespace Japanese.Models;

[DynamoDBTable("Kanjidic2")]
public class Kanjidic2Model
{
    [DynamoDBHashKey("literal")]
    public string? Literal { get; set; }

    [DynamoDBProperty("codepoints")]
    public List<CodepointModel>? Codepoints { get; set; }

    [DynamoDBProperty("radicals")]
    public List<RadicalModel>? Radicals { get; set; }

    [DynamoDBProperty("misc")]
    public MiscModel? Misc { get; set; }

    [DynamoDBProperty("dictionaryReferences")]
    public List<DictionaryReferenceModel>? DictionaryReferences { get; set; }

    [DynamoDBProperty("queryCodes")]
    public List<QueryCodeModel>? QueryCodes { get; set; }

    [DynamoDBProperty("readingMeaning")]
    public ReadingMeaningModel? ReadingMeaning { get; set; }

    
    public class CodepointModel
    {
        [DynamoDBProperty("type")]
        public string? Type { get; set; }

        [DynamoDBProperty("value")]
        public string? Value { get; set; }
    }

    public class RadicalModel
    {
        [DynamoDBProperty("type")]
        public string? Type { get; set; }

        [DynamoDBProperty("value")]
        public int? Value { get; set; }
    }

    public class MiscModel
    {
        [DynamoDBProperty("grade")]
        public int? Grade { get; set; }

        [DynamoDBProperty("strokeCounts")]
        public List<int>? StrokeCounts { get; set; }

        [DynamoDBProperty("variants")]
        public List<CodepointModel>? Variants { get; set; }

        [DynamoDBProperty("frequency")]
        public int? Frequency { get; set; }

        //[DynamoDBProperty("radicalNames")]
        //public List<object>? RadicalNames { get; set; }

        [DynamoDBProperty("jlptLevel")]
        public int? JlptLevel { get; set; }
    }

    public class DictionaryReferenceModel
    {
        [DynamoDBProperty("type")]
        public string? Type { get; set; }

        //[DynamoDBProperty("morohashi")]
        //[Alias("morohashi")]
        //public object? Morohashi { get; set; }

        [DynamoDBProperty("value")]
        public string? Value { get; set; }
    }

    public class QueryCodeModel
    {
        [DynamoDBProperty("type")]
        public string? Type { get; set; }

        //[DynamoDBProperty("skipMisclassification")]
        //[Alias("skipMisclassification")]
        //public object? SkipMisclassification { get; set; }

        [DynamoDBProperty("value")]
        public string? Value { get; set; }
    }

    public class ReadingMeaningModel
    {
        [DynamoDBProperty("groups")]
        public List<GroupModel>? Groups { get; set; }

        [DynamoDBProperty("nanori")]
        public List<string>? Nanori { get; set; }
    }

    public class GroupModel
    {
        [DynamoDBProperty("readings")]
        public List<ReadingModel>? Readings { get; set; }

        [DynamoDBProperty("meanings")]
        public List<MeaningModel>? Meanings { get; set; }
    }

    public class ReadingModel
    {
        [DynamoDBProperty("type")]
        public string? Type { get; set; }

        //[DynamoDBProperty("onType")]
        //public object? OnType { get; set; }

        //[DynamoDBProperty("status")]
        //public object? Status { get; set; }

        [DynamoDBProperty("value")]
        public string? Value { get; set; }
    }

    public class MeaningModel
    {
        [DynamoDBProperty("lang")]
        public string? Lang { get; set; }

        [DynamoDBProperty("value")]
        public string? Value { get; set; }
    }
}
