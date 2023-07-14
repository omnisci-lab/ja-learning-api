using AutoMapper;
using Japanese.Core.CommonModels;
using Japanese.Models;
using Japanese.Services.Sentence.Commands.CreateSentence;
using Japanese.Services.Sentence.Commands.UpdateSentence;
using Japanese.Services.Sentence.Queries;

namespace Japanese.Services.Sentence.Mappings;

public class SentenceMappingProfile : Profile
{
    public SentenceMappingProfile()
    {
        CreateMap<CreateSentenceCommand, SentenceModel>().ReverseMap();
        CreateMap<UpdateSentenceCommand, SentenceModel>().ReverseMap();
        CreateMap<SentenceModel, SentenceOutput>().ReverseMap();
        CreateMap<Pagination<SentenceModel>, Pagination<SentenceOutput>>().ReverseMap();
    }
}