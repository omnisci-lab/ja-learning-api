using AutoMapper;
using Japanese.Models;
using Japanese.Services.Kanji.Commands.CreateAndUpdateKanji;

namespace Japanese.Services.Kanji.Mappings;

public class CreateAndUpdateKanji_Kanji_Converter : ITypeConverter<CreateAndUpdateKanjiCommand, KanjiModel>
{
    public KanjiModel Convert(CreateAndUpdateKanjiCommand source, KanjiModel destination, ResolutionContext context)
    {
        destination.Character = source.Character!;
        destination.StrokeCount = source.StrokeCount;

        return destination;       
    }
}