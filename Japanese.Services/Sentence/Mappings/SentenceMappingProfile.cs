using AutoMapper;
using Japanese.Core.CommonModels;
using Japanese.Models;
using Japanese.Services.Sentence.Commands.CreateAndUpdateSentence;
using Japanese.Services.Sentence.Queries;

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