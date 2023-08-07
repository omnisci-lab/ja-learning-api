using AutoMapper;
using Japanese.Core.CommonModels;
using Japanese.Models;
using Japanese.Services.Kanji.Commands.CreateKanji;
using Japanese.Services.Kanji.Commands.UpdateKanji;
using Japanese.Services.Kanji.Queries;

namespace Japanese.Services.Kanji.Mappings;

public class KanjiMappingProfile : Profile
{
    public KanjiMappingProfile()
    {
        CreateMap<Kanjidic2Model, AdditionalKanjiModel>()
            .ConvertUsing<Kanjidic2_AdditionalKanji_Converter>();

        CreateMap<AdditionalKanjiModel, KanjiDetailOutput>()
           .ConvertUsing<AdditionalKanji_KanjiDetail_Converter>();

        CreateMap<KanjiComponentModel, KanjiDetailOutput>()
            .ConvertUsing<KanjiComponent_KanjiDetail_Converter>();

        CreateMap<PagedResult<JlptKanjiModel>, PagedResult<KanjiDetailOutput>>()
            .ConvertUsing<P_JlptKanji_P_KanjiDetail_Converter>();
        CreateMap<PagedResult<KankenModel>, PagedResult<KanjiDetailOutput>>()
            .ConvertUsing<P_Kanken_KanjiDetail_Converter>();

        CreateMap<CreateKanjiCommand, AdditionalKanjiModel>().ReverseMap();
        CreateMap<UpdateKanjiCommand, AdditionalKanjiModel>().ReverseMap();
    }
}