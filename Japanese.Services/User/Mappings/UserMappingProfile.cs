using AutoMapper;
using IdentityCore.Models;
using Japanese.Services.Features.User.Commands.SignIn;
using Japanese.Services.Features.User.Commands.SignUp;

namespace Japanese.Services.User.Mappings;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<SignUpCommand, UserModel>().ReverseMap();
        CreateMap<SignInCommand, UserModel>().ReverseMap();
    }
}