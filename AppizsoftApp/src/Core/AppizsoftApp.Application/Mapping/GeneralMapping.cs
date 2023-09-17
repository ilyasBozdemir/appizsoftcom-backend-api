using AppizsoftApp.Application.Dtos.Auth;
using AppizsoftApp.Application.Features.Auths.Commands;
using AppizsoftApp.Domain.Entities;
using AutoMapper;

namespace AppizsoftApp.Application.Mapping
{
    public class GeneralMapping : Profile
    {

        public GeneralMapping()
        {
            CreateMap<CreateUserCommand, UserForRegisterDto>().ReverseMap();
            CreateMap<User, UserForRegisterDto>().ReverseMap();
            CreateMap<User, CreateUserCommand>().ReverseMap();
        }
    }
}
