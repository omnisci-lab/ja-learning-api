using AutoMapper;
using Japanese.Core.CommonModels;
using Japanese.Models;
using Japanese.Services.Kanji.Commands.CreateKanji;
using Japanese.Services.Kanji.Commands.UpdateKanji;
using Japanese.Services.Kanji.Queries.GetKanji;

namespace Japanese.Services.Kanji.Mappings;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<CreateKanjiCommand, KanjiModel>().ReverseMap();
        CreateMap<UpdateKanjiCommand, KanjiModel>().ReverseMap();
        CreateMap<KanjiModel, KanjiDetailOutput>().ReverseMap();
        CreateMap<PagedResult<KanjiModel>, PagedResult<KanjiDetailOutput>>().ReverseMap();
    }
}