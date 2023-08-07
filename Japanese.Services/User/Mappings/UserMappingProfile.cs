using AutoMapper;
using Japanese.Core.CommonModels;
using Japanese.Models;
using Japanese.Services.Features.User.Commands.SignUp;

namespace Japanese.Services.User.Mappings;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<SignUpCommand, UserModel>().ReverseMap();
    }
}