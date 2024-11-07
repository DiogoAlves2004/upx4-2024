using AutoMapper;
using Infra.UPX4.Domain.Dto;
using Infra.UPX4.Domain.Models;

namespace Infra.UPX4.Ioc.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserModel, UserDto>().ReverseMap();
            
            CreateMap<PontoDeAcessibilidadeModel, PontoDeAcessibilidadeDto>().ReverseMap();

        }

    }
}