namespace Japanese.Services.Features.Kanji.Queries.GetKanji;

public class KanjiDetailOutput
{
    public string? Kanji { get; set; }
    public List<string>? OnReadings { get; set; }
    public List<string>? KunReadings { get; set; }
    public List<string>? NameReadings { get; set; }
}