using AutoMapper;
using Japanese.Models;
using Japanese.Services.Sentence.Commands.CreateAndUpdateSentence;
using Japanese.Services.Sentence.Queries;
using khothemegiatot.WebApi.Models;

namespace Japanese.Services.Sentence.Mappings;

public class SentenceMappingProfile : Profile
{
    public SentenceMappingProfile()
    {
        CreateMap<CreateAndUpdateSentenceCommand, SentenceModel>().ReverseMap();
        CreateMap<SentenceModel, SentenceOutput>().ReverseMap();
        CreateMap<PagedResult<SentenceModel>, PagedResult<SentenceOutput>>().ReverseMap();
    }
}