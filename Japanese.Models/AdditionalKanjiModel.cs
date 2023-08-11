using Amazon.DynamoDBv2.DataModel;
using ServiceStack.DataAnnotations;

namespace Japanese.Models;

[DynamoDBTable("AdditionalKanji")]
public class AdditionalKanjiModel : Kanjidic2Model
{
    public new AdditionalMiscModel? Misc { get; set; }

    public class AdditionalMiscModel : MiscModel
    {
        [DynamoDBProperty("kankenLevel")]
        [Alias("kankenLevel")]
        public string? KankenLevel { get; set; }
    }
}