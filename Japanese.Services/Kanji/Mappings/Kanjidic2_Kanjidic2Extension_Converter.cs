using AutoMapper;
using Japanese.Models;

namespace Japanese.Services.Kanji.Mappings;

public class Kanjidic2_Kanjidic2Extension_Converter : ITypeConverter<Kanjidic2Model, Kanjidic2ExtensionModel>
{
    public Kanjidic2ExtensionModel Convert(Kanjidic2Model source, Kanjidic2ExtensionModel destination, ResolutionContext context)
    {
        if (destination is null)
            return ConvertIfDestinationIsNull(source);

        return ConvertIfDestinationIsNotNull(source, destination);
    }

    private Kanjidic2ExtensionModel ConvertIfDestinationIsNull(Kanjidic2Model source)
    {
        Kanjidic2ExtensionModel destination = new Kanjidic2ExtensionModel();
        destination.Literal = source.Literal;
        destination.Codepoints = source.Codepoints;
        destination.Radicals = source.Radicals;
        destination.DictionaryReferences = source.DictionaryReferences;
        destination.QueryCodes = source.QueryCodes;
        destination.ReadingMeaning = source.ReadingMeaning;

        if(source.Misc is not null)
        {
            destination.Misc = new Kanjidic2ExtensionModel.AdditionalMiscModel
            {
                Grade = source.Misc.Grade,
                StrokeCounts = source.Misc.StrokeCounts,
                Variants = source.Misc.Variants,
                Frequency = source.Misc.Frequency,
                //RadicalNames = source.Misc.RadicalNames,
                JlptLevel = source.Misc.JlptLevel,
            };
        }

        return destination;
    }

    private Kanjidic2ExtensionModel ConvertIfDestinationIsNotNull(Kanjidic2Model source, Kanjidic2ExtensionModel destination)
    {


        return destination;
    }
}