using AutoMapper;
using Japanese.Models;
using Japanese.Services.Kanji.Queries;

namespace Japanese.Services.Kanji.Mappings;

public class KanjiComponent_KanjiDetail_Converter : ITypeConverter<KanjiComponentModel, KanjiDetailOutput>
{
    public KanjiDetailOutput Convert(KanjiComponentModel source, KanjiDetailOutput destination, ResolutionContext context)
    {
        if (destination is null)
            throw new NullReferenceException();

        destination.Components = source.Components;

        return destination;
    }
}