using AutoMapper;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System.Collections.Generic;
using Entities = IdentityServer4.EntityFramework.Entities;

namespace Plus.Infrastructure.IdentityServer.Core.Mapping
{
    public static class PlusClientGrantTypeMappers
    {
        static PlusClientGrantTypeMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ClientGrantTypeMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }

        public static Entities.ClientGrantType ToEntity(this ClientGrantType model)
        {
            return model == null ? null : Mapper.Map<Entities.ClientGrantType>(model);
        }


        public static ClientGrantType ToModel(this Entities.ClientGrantType entity)
        {
            return entity == null ? null : Mapper.Map<ClientGrantType>(entity);
        }

        public static List<ClientGrantType> ToModel(this List<Entities.ClientGrantType> entities)
        {
            var entityList = entities == null ? null : Mapper.Map<List<ClientGrantType>>(entities);
            return entityList;
        }
    }

    public class ClientGrantTypeMapperProfile : Profile
    {

        public ClientGrantTypeMapperProfile()
        {
            CreateMap<Entities.ClientGrantType, ClientGrantType>()
                .ConstructUsing(src => new ClientGrantType()).ReverseMap();
        }
    }
}
