namespace Japanese.Services.Kanji.Queries;

public class KanjiDetailOutput
{
    public string? Literal { get; set; }
    public int StrokeCount { get; set; }
    public int? Grade { get; set; }
    public int? Jlpt { get; set; }
    public List<string>? Components { get; set; }
    public List<string>? OnReadings { get; set; }
    public List<string>? KunReadings { get; set; }
    public List<string>? NameReadings { get; set; }
    public List<string>? EnMeanings { get; set; }
    public List<string>? SinoVietnamese { get; set; }
    public List<string>? ViMeanings { get; set; }
}