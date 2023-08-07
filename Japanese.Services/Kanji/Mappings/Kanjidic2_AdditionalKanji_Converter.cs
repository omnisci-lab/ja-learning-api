using AutoMapper;
using Japanese.Models;

namespace Japanese.Services.Kanji.Mappings;

public class Kanjidic2_AdditionalKanji_Converter : ITypeConverter<Kanjidic2Model, AdditionalKanjiModel>
{
    public AdditionalKanjiModel Convert(Kanjidic2Model source, AdditionalKanjiModel destination, ResolutionContext context)
    {
        if (destination is null)
            return ConvertIfDestinationIsNull(source);

        return ConvertIfDestinationIsNotNull(source, destination);
    }

    private AdditionalKanjiModel ConvertIfDestinationIsNull(Kanjidic2Model source)
    {
        AdditionalKanjiModel destination = new AdditionalKanjiModel();
        destination.Literal = source.Literal;
        destination.Codepoints = source.Codepoints;
        destination.Radicals = source.Radicals;
        destination.DictionaryReferences = source.DictionaryReferences;
        destination.QueryCodes = source.QueryCodes;
        destination.ReadingMeaning = source.ReadingMeaning;

        if(source.Misc is not null)
        {
            destination.Misc = new AdditionalKanjiModel.AdditionalMiscModel
            {
                Grade = source.Misc.Grade,
                StrokeCounts = source.Misc.StrokeCounts,
                Variants = source.Misc.Variants,
                Frequency = source.Misc.Frequency,
                RadicalNames = source.Misc.RadicalNames,
                JlptLevel = source.Misc.JlptLevel,
            };
        }

        return destination;
    }

    private AdditionalKanjiModel ConvertIfDestinationIsNotNull(Kanjidic2Model source, AdditionalKanjiModel destination)
    {


        return destination;
    }
}