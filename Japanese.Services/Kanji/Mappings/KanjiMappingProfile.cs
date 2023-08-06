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
        CreateMap<CreateKanjiCommand, KanjiModel>().ReverseMap();
        CreateMap<UpdateKanjiCommand, KanjiModel>().ReverseMap();
        CreateMap<Kanjidic2Model, KanjiDetailOutput>().ConvertUsing<Kanjidic2_KanjiDetail_Converter>();
        CreateMap<KanjiComponentModel, KanjiDetailOutput>()
            .ConvertUsing<KanjiComponent_KanjiDetail_Converter>();
        CreateMap<PagedResult<JlptKanjiModel>, PagedResult<KanjiDetailOutput>>()
            .ConvertUsing<P_JlptKanji_P_KanjiDetail_Converter>();
    }
}