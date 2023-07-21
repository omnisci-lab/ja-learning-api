using HtmlAgilityPack;

namespace Japanese.Plugin.HVDIC_THIVIEN_NET;

public class Hvdic_ThiVien_Net
{
    private HtmlWeb _htmlWeb;

    public Hvdic_ThiVien_Net()
    {
        _htmlWeb = new HtmlWeb();
    }

    public string GetSinoVietnamese(string kanji)
    {
        HtmlDocument htmlDocument = _htmlWeb.Load($"https://hvdic.thivien.net/whv/{kanji}");

        htmlDocument.DocumentNode.SelectNodes("//div[@class='hvres-meaning']");

        return null;
    }
}
