using Amazon.DynamoDBv2.DataModel;
using Japanese.Core.CommonModels;
using ServiceStack.DataAnnotations;

namespace Japanese.Models;

[DynamoDBTable("JMdict")]
[Alias("JMdict")]
public class JMdictModel : EntityBase
{
    [DynamoDBHashKey(AttributeName = "id")]
    [HashKey]
    [Alias("id")]
    public string? Id { get; set; }

    [DynamoDBProperty("kana")]
    [Alias("kana")]
    public List<KanaModel>? Kana { get; set; }

    [DynamoDBProperty("kanji")]
    [Alias("kanji")]
    public List<object>? Kanji { get; set; }

    [DynamoDBProperty("sense")]
    [Alias("sense")]
    public List<KanaModel>? Sense { get; set; }


    public class KanaModel
    {
        [DynamoDBProperty("appliesToKanji")]
        [Alias("appliesToKanji")]
        public List<string>? AppliesToKanji { get; set; }

        [DynamoDBProperty("common")]
        [Alias("common")]
        public bool Common { get; set; }

        [DynamoDBProperty("tags")]
        [Alias("tags")]
        public List<object>? Tags { get; set; }

        [DynamoDBProperty("text")]
        [Alias("text")]
        public string? Text { get; set; }
    }

    public class SenseModel
    {
        [DynamoDBProperty("antonym")]
        [Alias("antonym")]
        public List<object>? Antonym { get; set; }

        [DynamoDBProperty("appliesToKana")]
        [Alias("appliesToKana")]
        public List<string>? AppliesToKana { get; set; }

        [DynamoDBProperty("appliesToKanji")]
        [Alias("appliesToKanji")]
        public List<string>? AppliesToKanji { get; set; }

        [DynamoDBProperty("dialect")]
        [Alias("dialect")]
        public List<object>? Dialect { get; set; }

        [DynamoDBProperty("field")]
        [Alias("field")]
        public List<object>? Field { get; set; }

        [DynamoDBProperty("gloss")]
        [Alias("gloss")]
        public List<GlossModel>? Gloss { get; set; }

        [DynamoDBProperty("info")]
        [Alias("info")]
        public List<object>? Info { get; set; }

        [DynamoDBProperty("languageSource")]
        [Alias("languageSource")]
        public List<object>? LanguageSource { get; set; }

        [DynamoDBProperty("misc")]
        [Alias("misc")]
        public List<object>? Misc { get; set; }

        [DynamoDBProperty("partOfSpeech")]
        [Alias("partOfSpeech")]
        public List<string>? PartOfSpeech { get; set; }

        [DynamoDBProperty("related")]
        [Alias("related")]
        public List<List<string>>? Related { get; set; }
    }

    public class GlossModel
    {
        [DynamoDBProperty("gender")]
        [Alias("gender")]
        public object? Gender { get; set; }

        [DynamoDBProperty("lang")]
        [Alias("lang")]
        public string? Lang { get; set; }

        [DynamoDBProperty("text")]
        [Alias("text")]
        public string? Text { get; set; }

        [DynamoDBProperty("type")]
        [Alias("type")]
        public object? Type { get; set; }
    }
}
