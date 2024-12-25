using AutoMapper;
using Japanese.Models;
using Japanese.Services.Kanji.Commands.CreateAndUpdateKanji;
using Japanese.Services.Kanji.Queries;

namespace Japanese.Services.Kanji.Mappings;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<KanjiModel, KanjiDetailOutput>()
            .ConvertUsing<Kanji_KanjiDetail_Converter>();

        CreateMap<Kanjidic2Model, KanjiDetailOutput>()
           .ConvertUsing<Kanjidic2_KanjiDetail_Converter>();

        CreateMap<Kanjidic2Model, KanjiModel>()
            .ConvertUsing<Kanjidic2_Kanji_Converter>();

        CreateMap<KanjiComponentModel, KanjiDetailOutput>()
            .ConvertUsing<KanjiComponent_KanjiDetail_Converter>();

        CreateMap<CreateAndUpdateKanjiCommand, KanjiModel>()
            .ConvertUsing<CreateAndUpdateKanji_Kanji_Converter>();
    }
}