using AutoMapper;
using Japanese.Models;
using Japanese.Services.Kanji.Queries;

namespace Japanese.Services.Kanji.Mappings;

public class KanjiComponentModel_KanjiDetailOutput_Converter : ITypeConverter<KanjiComponentModel, KanjiDetailOutput>
{
    public KanjiDetailOutput Convert(KanjiComponentModel source, KanjiDetailOutput destination, ResolutionContext context)
    {
        if (destination == null)
            throw new NullReferenceException();

        destination.Components = source.Components;

        return destination;
    }
}