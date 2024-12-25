using AutoMapper;
using Japanese.Models;
using Japanese.Services.KanjiRadical.Commands.CreateAndUpdateKRadical;
using Japanese.Services.KanjiRadical.Queries;

namespace Japanese.Services.KanjiRadical.Mappings;

public class KRadicalMappingProfile : Profile
{
    public KRadicalMappingProfile() {
        CreateMap<KanjiRadicalModel, KRadicalDetailOutput>().ReverseMap();
        CreateMap<CreateAndUpdateKRadicalCommand, KanjiRadicalModel>().ReverseMap();
    }
}
