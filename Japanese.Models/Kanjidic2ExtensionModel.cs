using Amazon.DynamoDBv2.DataModel;

namespace Japanese.Models;

[DynamoDBTable("Kanjidic2Extensions")]
public class Kanjidic2ExtensionModel : Kanjidic2Model
{
    public new AdditionalMiscModel? Misc { get; set; }

    public class AdditionalMiscModel : MiscModel
    {
        [DynamoDBProperty("kankenLevel")]
        public string? KankenLevel { get; set; }
    }
}