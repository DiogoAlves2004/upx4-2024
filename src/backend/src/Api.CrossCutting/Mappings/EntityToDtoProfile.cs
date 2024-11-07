using AutoMapper;
using Infra.UPX4.Domain.Dto;
using Infra.UPX4.Domain.Entities;

namespace Infra.UPX4.Ioc.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<UserDto, UserEntity>().ReverseMap();

            CreateMap<PontoDeAcessibilidadeDto, PontoDeAcessibilidadeEntity>().ReverseMap();

        }
    }
}