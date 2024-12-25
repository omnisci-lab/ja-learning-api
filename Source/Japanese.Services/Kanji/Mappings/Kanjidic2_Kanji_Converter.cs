using AutoMapper;
using Japanese.Models;

namespace Japanese.Services.Kanji.Mappings;

public class Kanjidic2_Kanji_Converter : ITypeConverter<Kanjidic2Model, KanjiModel>
{
    public KanjiModel Convert(Kanjidic2Model source, KanjiModel destination, ResolutionContext context)
    {
        if (destination is null)
            destination = new KanjiModel();

        destination.Character = source.Literal!;

        if(source.Misc is not null)
        {
            if(source.Misc.JlptLevel is not null || source.Misc.Grade is not null)
            {
                destination.Level = new KanjiLevel { 
                    Grade = source.Misc.Grade, 
                    Jlpt = source.Misc.JlptLevel 
                };
            }
        }

        return destination;
    }
}