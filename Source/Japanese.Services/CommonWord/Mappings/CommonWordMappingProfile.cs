using AutoMapper;
using Japanese.Models;
using Japanese.Services.CommonWord.Queries;

namespace Japanese.Services.CommonWord.Mappings;

public class CommonWordMappingProfile : Profile
{
    public CommonWordMappingProfile() {
        CreateMap<CommonWordModel, CommonWordOutput>().ReverseMap();
    }
}
