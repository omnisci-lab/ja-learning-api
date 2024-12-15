namespace Japanese.Services.Kana.Queries;

public class KanaDetailOutput
{
    public string? Character { get; set; }

    public string? Romanization { get; set; }

    public string? KanaType { get; set; }

    public string? Row { get; set; }

    public string? Column { get; set; }

    public bool IsDakuten { get; set; }

    public bool IsHandakuten { get; set; }

    public string? Unicode { get; set; }

    public string? Description { get; set; }
}