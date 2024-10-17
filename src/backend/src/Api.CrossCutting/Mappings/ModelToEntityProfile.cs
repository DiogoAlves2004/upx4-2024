using AutoMapper;
using Infra.UPX4.Domain.Entities;
using Infra.UPX4.Domain.Models;

namespace Infra.UPX4.Ioc.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserModel, UserEntity>().ReverseMap();
        }
    }
}