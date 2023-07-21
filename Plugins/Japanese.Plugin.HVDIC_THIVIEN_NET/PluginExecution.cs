using Japanese.Core.Plugin;
using System.Reflection;

namespace Japanese.Plugin.HVDIC_THIVIEN_NET;

public class PluginExecution : IPluginExection
{
    private Hvdic_ThiVien_Net _hvdic_ThiVien_Net;

    public PluginExecution()
    {
        _hvdic_ThiVien_Net = new Hvdic_ThiVien_Net();
    }

    public void Run(object input)
    {
        Type inputType = input.GetType();

        if (inputType.Name != "GetKanjiQueryHandler")
            return;

        PropertyInfo? kanjiProperty = inputType.GetProperty("Kanji");
        if (kanjiProperty is null)
            return;

        object? kanji = kanjiProperty.GetValue(input);
        if (kanji is null)
            return;

        PropertyInfo? sinoVietnameseProperty = inputType.GetProperty("SinoVietnamese");
        if (sinoVietnameseProperty is null)
            return;
        
        object? sinoVietnamese = sinoVietnameseProperty.GetValue(input);
        if (sinoVietnamese is not null)
            sinoVietnameseProperty.SetValue(input, _hvdic_ThiVien_Net.GetSinoVietnamese(kanji?.ToString()!));

        PropertyInfo? viMeaningsProperty = inputType.GetProperty("ViMeanings");
        if (viMeaningsProperty is null)
            return;

        object? viMeanings = viMeaningsProperty.GetValue(input);
        if (viMeanings is not null)
            (viMeanings as List<string>)!.AddRange(null);
    }
}