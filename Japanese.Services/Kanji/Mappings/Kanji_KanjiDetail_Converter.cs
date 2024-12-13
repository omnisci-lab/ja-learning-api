using AutoMapper;
using Japanese.Models;
using Japanese.Services.Kanji.Queries;

namespace Japanese.Services.Kanji.Mappings;

public class Kanji_KanjiDetail_Converter : ITypeConverter<KanjiModel, KanjiDetailOutput>
{
    public KanjiDetailOutput Convert(KanjiModel source, KanjiDetailOutput destination, ResolutionContext context)
    {
        if (destination is null)
            destination = new KanjiDetailOutput();

        destination.Literal = source.Character;

        return destination;
    }
}