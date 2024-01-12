using AutoMapper;
using Japanese.Models;

namespace Japanese.Services.Kanji.Mappings;

public class Kanjidic2Extension_Kanjidic2_Converter : ITypeConverter<Kanjidic2ExtensionModel, Kanjidic2Model>
{
    public Kanjidic2Model Convert(Kanjidic2ExtensionModel source, Kanjidic2Model destination, ResolutionContext context)
    {
        if (destination is null)
            throw new ArgumentNullException(nameof(destination));

        if (source is null)
            return destination;

        if(source.JlptLevel is not null && destination.Misc is not null)
            destination.Misc.JlptLevel = source.JlptLevel;

        if (source.KankenLevel is not null && destination.Misc is not null)
            destination.Misc.KankenLevel = source.KankenLevel;

        return destination;
    }
}