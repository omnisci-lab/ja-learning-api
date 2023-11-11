using AutoMapper;
using Japanese.Models;
using Japanese.Services.Kanji.Commands.CreateKanji;
using Japanese.Services.Kanji.Commands.UpdateKanji;
using Japanese.Services.Kanji.Queries;

namespace Japanese.Services.Kanji.Mappings;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<Kanjidic2Model, Kanjidic2ExtensionModel>()
            .ConvertUsing<Kanjidic2_Kanjidic2Extension_Converter>();

        CreateMap<Kanjidic2ExtensionModel, KanjiDetailOutput>()
           .ConvertUsing<Kanjidic2Extension_KanjiDetail_Converter>();

        CreateMap<KanjiComponentModel, KanjiDetailOutput>()
            .ConvertUsing<KanjiComponent_KanjiDetail_Converter>();

        CreateMap<CreateKanjiCommand, Kanjidic2ExtensionModel>().ReverseMap();
        CreateMap<UpdateKanjiCommand, Kanjidic2ExtensionModel>().ReverseMap();
    }
}