namespace Japanese.Services.Features.Kanji.Queries.GetKanji;

public class KanjiDetailOutput
{
    public string? Kanji { get; set; }
    public int StrokeCount { get; set; }
    public int? Grade { get; set; }
    public List<string>? OnReadings { get; set; }
    public List<string>? KunReadings { get; set; }
    public List<string>? NameReadings { get; set; }
    public List<string>? Meanings { get; set; }
    public int? Jlpt { get; set; }
    public string? Unicode { get; set; }
}