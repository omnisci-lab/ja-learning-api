using Amazon.DynamoDBv2.DataModel;

namespace Japanese.Models;

[DynamoDBTable("JMdict")]
public class JMdictModel
{
    [DynamoDBHashKey(AttributeName = "id")]
    public string? Id { get; set; }

    [DynamoDBProperty("kana")]
    public List<KanaModel>? Kana { get; set; }

    [DynamoDBProperty("kanji")]
    public List<object>? Kanji { get; set; }

    [DynamoDBProperty("sense")]
    public List<KanaModel>? Sense { get; set; }


    public class KanaModel
    {
        [DynamoDBProperty("appliesToKanji")]
        public List<string>? AppliesToKanji { get; set; }

        [DynamoDBProperty("common")]
        public bool Common { get; set; }

        [DynamoDBProperty("tags")]
        public List<object>? Tags { get; set; }

        [DynamoDBProperty("text")]
        public string? Text { get; set; }
    }

    public class SenseModel
    {
        [DynamoDBProperty("antonym")]
        public List<object>? Antonym { get; set; }

        [DynamoDBProperty("appliesToKana")]
        public List<string>? AppliesToKana { get; set; }

        [DynamoDBProperty("appliesToKanji")]
        public List<string>? AppliesToKanji { get; set; }

        [DynamoDBProperty("dialect")]
        public List<object>? Dialect { get; set; }

        [DynamoDBProperty("field")]
        public List<object>? Field { get; set; }

        [DynamoDBProperty("gloss")]
        public List<GlossModel>? Gloss { get; set; }

        [DynamoDBProperty("info")]
        public List<object>? Info { get; set; }

        [DynamoDBProperty("languageSource")]
        public List<object>? LanguageSource { get; set; }

        [DynamoDBProperty("misc")]
        public List<object>? Misc { get; set; }

        [DynamoDBProperty("partOfSpeech")]
        public List<string>? PartOfSpeech { get; set; }

        [DynamoDBProperty("related")]
        public List<List<string>>? Related { get; set; }
    }

    public class GlossModel
    {
        [DynamoDBProperty("gender")]
        public object? Gender { get; set; }

        [DynamoDBProperty("lang")]
        public string? Lang { get; set; }

        [DynamoDBProperty("text")]
        public string? Text { get; set; }

        [DynamoDBProperty("type")]
        public object? Type { get; set; }
    }
}
