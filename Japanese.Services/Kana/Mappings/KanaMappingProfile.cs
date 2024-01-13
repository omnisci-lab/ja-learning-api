using AutoMapper;
using Japanese.Models;
using Japanese.Services.Kana.Queries;

namespace Japanese.Services.Kana.Mappings;

public class KanaMappingProfile : Profile
{
    public KanaMappingProfile()
    {
        CreateMap<KanaModel, KanaDetailOutput>().ReverseMap();
    }
}
