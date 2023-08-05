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
        CreateMap<KanjiModel, KanjiDetailOutput>().ReverseMap();
        CreateMap<Kanjidic2Model, KanjiDetailOutput>().ConvertUsing<KanjiDetailConverter>();
        CreateMap<KanjiComponentModel, KanjiDetailOutput>().ConvertUsing<KanjiComponentModel_KanjiDetailOutput_Converter>();
        CreateMap<PagedResult<KanjiModel>, PagedResult<KanjiDetailOutput>>().ReverseMap();
        CreateMap<PagedResult<JlptKanjiModel>, PagedResult<KanjiDetailOutput>>().ReverseMap();
    }
}