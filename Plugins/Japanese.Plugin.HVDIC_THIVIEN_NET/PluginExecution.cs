using Japanese.Core.CommonModels;
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

    public void Run(object? request, object? response)
    {
        PropertyInfo? dataProperty = response.GetType().GetProperty(nameof(ExecResult<object>.Data));
        if (dataProperty is null)
            return;

        object? value = dataProperty.GetValue(response);
        Type valueType = value.GetType();

        if (valueType.Name != "KanjiDetailOutput")
            return;

        PropertyInfo? kanjiProperty = valueType.GetProperty("Kanji");
        if (kanjiProperty is null)
            return;

        object? kanji = kanjiProperty.GetValue(value);
        if (kanji is null)
            return;

        PropertyInfo? sinoVietnameseProperty = valueType.GetProperty("SinoVietnamese");
        if (sinoVietnameseProperty is null)
            return;
        
        object? sinoVietnamese = sinoVietnameseProperty.GetValue(value);
        if (sinoVietnamese is null)
            //sinoVietnameseProperty.SetValue(input, _hvdic_ThiVien_Net.GetSinoVietnamese(kanji?.ToString()!));
            sinoVietnameseProperty.SetValue(value, "SinoVietnamese");

        PropertyInfo? viMeaningsProperty = valueType.GetProperty("ViMeanings");
        if (viMeaningsProperty is null)
            return;

        object? viMeanings = viMeaningsProperty.GetValue(value);
        if (viMeanings is not null)
            (viMeanings as List<string>)!.AddRange(new List<string> { "1", "2", "3", "4", "5" });
    }
}